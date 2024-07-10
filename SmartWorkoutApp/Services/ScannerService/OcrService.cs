﻿using System.Text;
using IronOcr;

namespace SmartWorkoutApp.Services.ScannerService;

 public class OcrService : IOcrService
    {
        public string ExtractTextFromImage(byte[] imageBytes)
        {
            IronOcr.License.LicenseKey = "IRONSUITE.DAVIDSTANA4.GMAIL.COM.6432-282DF58504-HE2U4XFFAIDOXM-FXPDOAPFCWM2-BD2PSFNMSZTI-INZUF6EBWTAX-B56BABQPAUMB-CWSVNV6MLR24-I6HTGT-TKOELSYOPJKNEA-DEPLOYMENT.TRIAL-3UIOI5.TRIAL.EXPIRES.09.AUG.2024";
            var ocr = new IronTesseract();
            try
            {
                using (var input = new OcrInput(imageBytes))
                {
                    var result = ocr.Read(input);
                    return result.Text;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
                return string.Empty;
            }
        }

        public MrzData ExtractMrzData(string ocrText)
        {
            var lines = ocrText.Split('\n');
            string firstLine = null;
            string secondLine = null;
            for (int i = 0; i < lines.Length - 1; i++)
            {
                if (lines[i].StartsWith("ID"))
                {
                    firstLine = lines[i].Trim();
                    
                    if (i + 1 < lines.Length)
                    {
                        secondLine = lines[i + 1].Trim();
                        break; 
                    }
                }
            }

            if (firstLine != null && secondLine != null)
            {
                var country = " ";
                var cetatenie = " ";
                var documentType = firstLine.Substring(0, 2);
                var countryMrz = firstLine.Substring(2, 3);
                if (countryMrz == "ROU")
                {
                    country = "Romania";
                    cetatenie = "Roman";
                }

                var cnp = secondLine.Substring(28,1) +
                    secondLine.Substring(13, 6) + secondLine.Substring(29, 6);
                var nume = ExtractNume(firstLine);
                var prenume = ExtractPrenume(firstLine) + ExtractAlDoileaPrenume(firstLine);

                var sex = "";
                var sex_ = secondLine.Substring(20, 1);
                if (sex_ == "m")
                {
                    sex = "Barbat";
                }
                else if (sex_ == "f")
                {
                    sex = "Femeie";
                }

                var judet = "";
                var judet_ = cnp.Substring(7, 2);
                if (judet_ == "02")
                {
                    judet = "Arad";
                }//am pus doar pentru Arad
                

                return new MrzData
                {
                    Name = nume,
                    Surname = prenume,
                    CNP = cnp,
                    Sex=sex,
                    Cetatenie = cetatenie,
                    Judet = judet
                };
            }
            else
            {
                throw new Exception("OCR text does not contain enough lines starting with 'ID' to extract MRZ data.");
            }
        }

        private static int index = 0;

        private string ExtractNume(string line)
        {
            var nume = new StringBuilder();
            index = 5;

            while (index < line.Length && line[index] != '<')
            {
                nume.Append(line[index]);
                index++;
            }

            index += 2; // Move past the '<<'
            if (index >= line.Length)
            {
                throw new Exception("The line does not contain a valid name format.");
            }

            return nume.ToString().Trim();
        }

        private string ExtractPrenume(string line)
        {
            var prenume = new StringBuilder();

            while (index < line.Length && line[index] != '<')
            {
                prenume.Append(line[index]);
                index++;
            }

            return prenume.ToString().Trim();
        }
        
        private string ExtractAlDoileaPrenume(string line)
        {
            var prenume2 = new StringBuilder();

            while (index < line.Length && line[index] != '<')
            {
                prenume2.Append(line[index]);
                index++;
            }

            return prenume2.ToString().Trim();
        }
    }