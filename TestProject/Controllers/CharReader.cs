//-----------------------------------------------------------------------
// <copyright file="CharReader.cs" company="">
//     Copyright. All rights reserved.
// </copyright>
// <author>Syahrul Munif</author>
//-----------------------------------------------------------------------

namespace TestProject.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// CharReader Class for read number.
    /// </summary>
    public class CharReader
    {
        
		private string dataToPrint;

		public String DataToPrint
		{
			get { return this.dataToPrint; }
			set { this.dataToPrint = value.ToString();}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="CharReader"/> class.
        /// </summary>
        /// <param name="input">The input.</param>
        public CharReader(string input)
        {
			input = input.Replace(",", "");
			List<String> inputString = input.Split('.').ToList();
			foreach (String inputData in inputString){
				List<String> resultSplit = this.SplitString(inputData);
				if (!String.IsNullOrEmpty(this.DataToPrint) && !String.IsNullOrEmpty(inputData) && resultSplit.Count() > 0 && !inputData.Replace("0", "").Equals("")){
					this.DataToPrint += " And ";
				}
				this.ReadChar(resultSplit);
				if (!String.IsNullOrEmpty(this.DataToPrint) && !String.IsNullOrEmpty(inputData) && resultSplit.Count() > 0 && inputString.IndexOf(inputData).Equals(0))
				{
					this.DataToPrint += " Dollars ";
				}
			}
			if (inputString.Count() > 1)
			{
				if (!inputString.ElementAt(1).Replace("0", "").Equals("")) this.DataToPrint += " Cents";
			}
            
        }

        /// <summary>
        /// Gets or sets the result split.
        /// Store value from split string.
        /// </summary>
        /// <value>
        /// The result split.
        /// </value>
        public List<string> ResultSplit { get; set; }

        /// <summary>
        /// Splits the string.
        /// This method split string with 3 char per each string result.
        /// example : 1234 will be 2 strings 1, 234
        /// </summary>
		private List<String> SplitString(String inputString)
        {
            List<String> resultSplit = new List<string>();
			char[] reverse = inputString.Reverse().ToArray();
            string input2 = new string(reverse);
            for (var i = 0; i < input2.Length; i += 3)
            {
				resultSplit.Add(input2.Substring(i, Math.Min(3, input2.Length - i)));
            }
			return resultSplit;
        }

         /// <summary>
         /// Reads the char.
         /// Reads the string and convert it to words.
         /// </summary>
         private void ReadChar(List<String> resultSplit)
         {
			int marks = resultSplit.Count();
			string[] resultSplitArray = resultSplit.ToArray();
             for (int y = marks - 1; y > -1; y--)
             {
                 if (resultSplitArray[y].Replace("0", "").Length > 0)
                 {
                     this.ReadPerChar(new string(resultSplitArray[y].Reverse().ToArray()));
                     this.Print(this.ReadDigitBefore(y));
                 }
             }
         }

         /// <summary>
         /// Reads per char.
         /// Reads the char in string, translate it to words
         /// </summary>
         /// <param name="inputNumber">The input number.</param>
        private void ReadPerChar(string inputNumber)
        {
            char[] charTemporary = inputNumber.ToCharArray();
            for (int y = 0; y < charTemporary.Count(); y++)
            {
                if (charTemporary[y] == '1')
                {
                    if (y + 1 == charTemporary.Count() - 1)
                    {
                        this.Print(this.ReadGenerator(charTemporary[y + 1].ToString(), true));
                        y++;
                    }
                    else
                    {
                        this.Print(this.ReadGenerator(charTemporary[y].ToString(), false));
                    }
                }
                else if (charTemporary[y] != '0')
                {
                    if (y + 1 == charTemporary.Count() - 1)
                    {
						this.DataToPrint += this.TenNeeded(charTemporary[y].ToString());
                        if (charTemporary[y + 1] != '0')
                        {
							this.DataToPrint+= "-";
                        }
                        else
                        {
							this.DataToPrint += " ";
                        }
                    }
                    else
                    {
                        this.Print(this.ReadGenerator(charTemporary[y].ToString(), false));
                    }
                }

                if (charTemporary[y] != '0' && y == 0 && charTemporary.Count() == 3)
                {
                    this.Print("Hundred");
                }
            }
        }

        /// <summary>
        /// Prints the specified print.
        /// </summary>
        /// <param name="print">The print.</param>
        private void Print(string print)
        {
			this.DataToPrint += (print == string.Empty ? string.Empty : print + " ");
        }

        /// <summary>
        /// Reads the digit before.
        /// </summary>
        /// <param name="digitCount">The digit count.</param>
        /// <returns>String of number's words</returns>
        private string ReadDigitBefore(int digitCount)
        { 
            switch (digitCount)
            {
                case 1:
                    return "Thousand";
                case 2:
                    return "Million";
                case 3:
                    return "Billion";
                case 4:
                    return "Trillion";
                case 5:
                    return "Quadrillion";
                case 6:
                    return "Quintillion";
                default:
                    return string.Empty;
            }
        }

		/// <summary>
		/// Tens the needed.
		/// </summary>
		/// <param name="number">The number.</param>
		/// <returns>String of number's words</returns>
		private string TenNeeded(string number)
        {
            switch (number)
            {
                case "2": return "Twenty";
                case "3": return "Thirty";
                case "4": return "Fourty";
                case "5": return "Fifty";
                case "6": return "Sixty";
                case "7": return "Seventy";
                case "8": return "Eighty";
                case "9": return "Ninety";
                default: return string.Empty;
            }
        }

        /// <summary>
        /// Reads the generator.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="diff">if set to <c>true</c> [diff].</param>
        /// <returns>String of number's words</returns>
        private string ReadGenerator(string number, bool diff)
        {
            switch (number)
            {
                case "0":
                    return "Ten";
                case "1":
                    return !diff ? "One" : "Eleven";
                case "2":
                    return !diff ? "Two" : "Twelve";
                case "3":
                    return !diff ? "Three" : "Thirteen";
                case "4":
                    return !diff ? "Four" : "Fourteen";
                case "5":
                    return !diff ? "Five" : "Fiveteen";
                case "6":
                    return !diff ? "Six" : "Sixteen";
                case "7":
                    return !diff ? "Seven" : "Seventeen";
                case "8":
                    return !diff ? "Eight" : "Eightteen";
                case "9":
                    return !diff ? "Nine" : "Nineteen";
                default:
                    return string.Empty;
            }
        }
    }
}
