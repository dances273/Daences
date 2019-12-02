using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Credit_card
{
    public class Generate
    {
        public static string[] AMEX_PREFIX_LIST = new[] { "34", "37" };


        public static string[] DINERS_PREFIX_LIST = new[]
                                                        {
                                                            "300",
                                                            "301", "302", "303", "36", "38"
                                                        };


        public static string[] DISCOVER_PREFIX_LIST = new[] { "6011" };


        public static string[] ENROUTE_PREFIX_LIST = new[]
                                                        {
                                                            "2014",
                                                            "2149"
                                                        };


        public static string[] JCB_15_PREFIX_LIST = new[]
                                                        {
                                                            "2100",
                                                            "1800"
                                                        };


        public static string[] JCB_16_PREFIX_LIST = new[]
                                                        {
                                                            "3088",
                                                            "3096", "3112", "3158", "3337", "3528"
                                                        };


        public static string[] MASTERCARD_PREFIX_LIST = new[]
                                                            {
                                                                "51",
                                                                "52", "53", "54", "55"
                                                            };


        public static string[] VISA_PREFIX_LIST = new[]
                                                    {
                                                        "4539",
                                                        "4556", "4916", "4532", "4929", "40240071", "4485", "4716", "4"
                                                    };


        public static string[] VOYAGER_PREFIX_LIST = new[] { "8699" };

        /*
      'prefix' is the start of the  CC number as a string, any number
        private of digits   'length' is the length of the CC number to generate.
     * Typically 13 or  16
        */
        private static string CreateFakeCreditCardNumber(string prefix, int length)
        {
            string ccnumber = prefix;

            while (ccnumber.Length < (length - 1))
            {
                double rnd = (new Random().NextDouble() * 1.0f - 0f);

                ccnumber += Math.Floor(rnd * 10);

                //sleep so we get a different seed

                Thread.Sleep(20);
            }


            // reverse number and convert to int
            var reversedCCnumberstring = ccnumber.ToCharArray().Reverse();

            var reversedCCnumberList = reversedCCnumberstring.Select(c => Convert.ToInt32(c.ToString()));

            // calculate sum

            int sum = 0;
            int pos = 0;
            int[] reversedCCnumber = reversedCCnumberList.ToArray();

            while (pos < length - 1)
            {
                int odd = reversedCCnumber[pos] * 2;

                if (odd > 9)
                    odd -= 9;

                sum += odd;

                if (pos != (length - 2))
                    sum += reversedCCnumber[pos + 1];

                pos += 2;
            }

            // calculate check digit
            int checkdigit =
                Convert.ToInt32((Math.Floor((decimal)sum / 10) + 1) * 10 - sum) % 10;

            ccnumber += checkdigit;

            return ccnumber;
        }

        public static string GenerateCardNumber(string[] prefixList, int length)
        {
            int randomPrefix = new Random().Next(0, prefixList.Length - 1);

            if (randomPrefix > 1)
            {
                randomPrefix--;
            }

            string ccnumber = prefixList[randomPrefix];

            return CreateFakeCreditCardNumber(ccnumber, length);
        }
        public string CVV(string cardnumber)
        {
            string masodik;
            string harmadik;
            string negyedik;
            string m2 = "";
            string m3 = "";
            string m4 = "";
            if (cardnumber.Length == 16)
            {
                masodik = cardnumber.Substring(4, 4);
                harmadik = cardnumber.Substring(8, 4);
                negyedik = cardnumber.Substring(12, 4);
            }
            else
            {
                masodik = cardnumber.Substring(4, 4);
                harmadik = cardnumber.Substring(8, 4);
                negyedik = cardnumber.Substring(12, 3);
            }
            for (int i = 0; i < 3; i++)
            {
                int sum = 0;
                int pos = 0;
                switch (i)
                {
                    case 0:
                        var masodList = masodik.Select(c => Convert.ToInt32(c.ToString()));

                        int[] ketto = masodList.ToArray();
                        while (pos < masodik.Length)
                        {
                            
                            if ((pos % 2) == 0)//Páratlan helyen álló számot megszoroz 1-el.
                            {
                                sum += ketto[pos] * 1;
                                pos++;
                            }
                            else //Páros helyen álló számot megszoros 3-mal
                            {
                                sum += ketto[pos] * 3;
                                pos++;
                            }
                        }
                        m2 = Convert.ToString(((Math.Floor((decimal)sum / 10) + 1) * 10 - sum) % 10); //Kapok számot elosztja maradékosan és 10-re való kiegészíthez való számot adja

                        break;
                    case 1:
                        var harmadList = harmadik.Select(c => Convert.ToInt32(c.ToString()));

                        int[] harom = harmadList.ToArray();
                        while (pos < harmadik.Length)
                        {
                            if ((pos % 2) == 0)
                            {
                                sum += harom[pos] * 1;//Páratlan helyen álló számot megszoroz 1-el.
                                pos++;
                            }
                            else
                            {
                                sum += harom[pos] * 3;//Páros helyen álló számot megszoros 3-mal
                                pos++;
                            }
                        }
                        m3 = Convert.ToString(((Math.Floor((decimal)sum / 10) + 1) * 10 - sum) % 10);//Kapok számot elosztja maradékosan és 10-re való kiegészíthez való számot adja
                        break;
                    case 2:
                        var negyedList = negyedik.Select(c => Convert.ToInt32(c.ToString()));

                        int[] negy = negyedList.ToArray();
                        while (pos < negyedik.Length)
                        {
                            if ((pos % 2) == 0)
                            {
                                sum += negy[pos] * 1;//Páratlan helyen álló számot megszoroz 1-el.
                                pos++;
                            }
                            else
                            {
                                sum += negy[pos] * 3;//Páros helyen álló számot megszoros 3-mal
                                pos++;
                            }
                        }
                        m4 = Convert.ToString(((Math.Floor((decimal)sum / 10) + 1) * 10 - sum) % 10);//Kapok számot elosztja maradékosan és 10-re való kiegészíthez való számot adja
                        break;
                    default:
                        break;
                }
            }
            return string.Format("{0}{1}{2}", m2, m3, m4);
        }
        public bool Valódi(string creditCardNumber)//Megvizsgálja,hogy a kártyaszám valódi-e
        {
            try
            {
                double sum = 0;
                for (int i = 0; i <= creditCardNumber.Length - 1; i++)
                {
                    double akt = char.GetNumericValue(creditCardNumber, i);
                    if ((i % 2) == 0)
                    {
                        if (akt > 4)
                        {
                            sum = sum + 2 * akt - 9;
                        }
                        else
                        {
                            sum = sum + 2 * akt;
                        }
                    }
                    else
                    {
                        sum = sum + akt;
                    }
                }
                if ((sum % 10) == 0)//Ha a számot elosztjuk maradékosan 10-el és 0 az eredmény akkor valódi a kártya!
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;


        }
    }
}

