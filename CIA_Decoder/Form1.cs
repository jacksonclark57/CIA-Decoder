using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CIA_Decoder
{
    public partial class Form1 : Form
    {

        Dictionary<int, string> EncodeDictionary = new Dictionary<int, string>();
        List<string> commentStrings = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }



        private void OpenFile_Click(object sender, EventArgs e)
        {
            commentStrings.Clear();
            P6_Reader P6Sender = new P6_Reader();
            DialogResult dgrTemp = OpenFile.ShowDialog();
            string fileFormat = "";
            if (dgrTemp == DialogResult.OK)
            {
                
                secretCodeTXT.Text = null;

                StreamReader InputFormat = new StreamReader(OpenFile.FileName);
                fileFormat = InputFormat.ReadLine();
                InputFormat.Close();

                if (fileFormat == "P3")
                {
                    //Read p3 
                    #region p3 reader
                    //open the menu then open a file
                    StreamReader Inputfile = new StreamReader(OpenFile.FileName);
                    string imgType = Inputfile.ReadLine();
                    //string Imgcomment = Inputfile.ReadLine();
                    int imgLength = 0;
                    int imgWidth = 0;
                    char[] length_width;
                    string currentNum = "";
                    bool commentsEnd = false;
                    int count = 0;
                    string LW = "";

                     while (commentsEnd == false)
                     {
                        //add comment too the list
                        commentStrings.Add(Inputfile.ReadLine());
                         if (!commentStrings[count].Contains("#"))
                         {
                             commentsEnd = true;
                             //take the next line and turn into Length and Width
                             LW = commentStrings[count];
                             //remove length and width from list
                             commentStrings.RemoveAt(count);
                         }
                         count++;
                     }
                    length_width = LW.ToCharArray();

                    Inputfile.ReadLine();
                    //Loop through char array
                    for (int index = 0; index < length_width.Length; index++)
                    {
                        //if the char array reaches a space it assigns the current number to Imglength
                        if (length_width[index] == ' ')
                        {
                            imgWidth = int.Parse(currentNum);
                            currentNum = "";
                        }
                        //if the number is parseable it adds it to current number
                        else if (int.Parse(length_width[index].ToString()) >= 0 && int.Parse(length_width[index].ToString()) <= 9)
                        {
                            currentNum += length_width[index];
                        }
                        if (int.TryParse(currentNum, out _) && imgWidth != 0)
                        {
                            imgLength = int.Parse(currentNum);
                        }
                    }
                    //generate new bitmap after gathering all essintal info
                    Bitmap P3IMG = new Bitmap(imgWidth, imgLength);
                    
                    
                    //loop through the x and y by grabbing three lines of RGB values for each pixel
                    for (int totalY = 0; totalY < imgLength; totalY++)
                    {
                        for (int totalX = 0; totalX < imgWidth; totalX++)
                        {
                            int redVal = int.Parse(Inputfile.ReadLine());
                            int grnVal = int.Parse(Inputfile.ReadLine());
                            int bluVal = int.Parse(Inputfile.ReadLine());
                            Color colCurrent = Color.FromArgb(redVal, grnVal, bluVal);
                            //add the pixels that are appropriate for beung used to encode


                            P3IMG.SetPixel(totalX, totalY, colCurrent);
                            
                        }
                    }
                    //set P3IMG to the user selected picture box
                    UndecodedIMG.Image = P3IMG;
                    #endregion
                }
                if (fileFormat == "P6")
                {
                    //Read p6 
                    #region P6 Reader
                    StreamReader p6Header = new StreamReader(OpenFile.FileName);

                    // string Imgcomment = Inputfile.ReadLine();

                    bool commentsEnd = false;
                    List<string> comments = new List<string>();
                    string format = p6Header.ReadLine();
                    int count = 0;
                    string LW = "";
                    // grab all the comments and add to the global list
                    while (commentsEnd == false)
                    {
                        //add comment too the list
                        comments.Add(p6Header.ReadLine());
                        if (!comments[count].Contains("#"))
                        {
                            commentsEnd = true;
                            //take the next line and turn into Length and Width
                            LW = comments[count];
                            //remove length and width from list
                            comments.RemoveAt(count);
                        }
                        count++;
                    }
                    
                    char[] length_width = LW.ToCharArray();
                    string maxpix = p6Header.ReadLine();
                    
                    int imgLength = 0;
                    int imgWidth = 0;
                    
                    string currentNum = "";
                    //Loop through char array
                    for (int index = 0; index < length_width.Length; index++)
                    {
                        //if the char array reaches a space it assigns the current number to img width
                        if (length_width[index] == ' ')
                        {
                            imgWidth = int.Parse(currentNum);
                            currentNum = "";
                        }
                        //if the number is parseable it adds it to current number
                        else if (int.Parse(length_width[index].ToString()) >= 0 && int.Parse(length_width[index].ToString()) <= 9)
                        {
                            currentNum += length_width[index];
                        }
                        if (int.TryParse(currentNum, out _) && imgWidth != 0)
                        {
                            imgLength = int.Parse(currentNum);
                        }
                    }
                    p6Header.Close();
                    #endregion
                    UndecodedIMG.Image = P6Sender.LoadPPM(OpenFile.FileName, imgWidth, imgLength,comments);
                }

            }
        }

        private void Decipher_Click(object sender, EventArgs e)
        {
            if (UndecodedIMG.Image != null)
            {
                //reset the status of the text box and the progress bar
                decoder(builDic());
            }
            else
            {
                //send the user a error message
                MessageBox.Show("Please load a file before deciphering it", "Decoding Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        public Dictionary<int, string> builDic()
        {
            Dictionary<int, string> EncodeDictionary = new Dictionary<int, string>();

            EncodeDictionary.Add(97, "a"); EncodeDictionary.Add(110, "n"); EncodeDictionary.Add(32, " ");
            EncodeDictionary.Add(98, "b"); EncodeDictionary.Add(111, "o"); EncodeDictionary.Add(48, "0");
            EncodeDictionary.Add(99, "c"); EncodeDictionary.Add(112, "p"); EncodeDictionary.Add(49, "1");
            EncodeDictionary.Add(100, "d"); EncodeDictionary.Add(113, "q"); EncodeDictionary.Add(50, "2");
            EncodeDictionary.Add(101, "e"); EncodeDictionary.Add(114, "r"); EncodeDictionary.Add(51, "3");
            EncodeDictionary.Add(102, "f"); EncodeDictionary.Add(115, "s"); EncodeDictionary.Add(52, "4");
            EncodeDictionary.Add(103, "g"); EncodeDictionary.Add(116, "t"); EncodeDictionary.Add(53, "5");
            EncodeDictionary.Add(104, "h"); EncodeDictionary.Add(117, "u"); EncodeDictionary.Add(54, "6");
            EncodeDictionary.Add(105, "i"); EncodeDictionary.Add(118, "v"); EncodeDictionary.Add(55, "7");
            EncodeDictionary.Add(106, "j"); EncodeDictionary.Add(119, "w"); EncodeDictionary.Add(56, "8");
            EncodeDictionary.Add(107, "k"); EncodeDictionary.Add(120, "x"); EncodeDictionary.Add(57, "9");
            EncodeDictionary.Add(108, "l"); EncodeDictionary.Add(121, "y");
            EncodeDictionary.Add(109, "m"); EncodeDictionary.Add(122, "z");
            return EncodeDictionary;
        }
        public void decoder(Dictionary<int, string> askivals)
        {
            string secretCode = "";
            Bitmap UserImg = new Bitmap(UndecodedIMG.Image);
            Color curPix = new Color();

            for (int totalY = 0; totalY < UndecodedIMG.Image.Height; totalY++)
            {
                for (int totalX = 0; totalX < UndecodedIMG.Image.Width; totalX++)
                {
                    curPix = UserImg.GetPixel(totalX, totalY);
                    if (askivals.ContainsKey(curPix.B))
                    {
                        string temp = "";
                        askivals.TryGetValue(curPix.B, out temp);
                        secretCode += temp;
                    }
                }
            }
            secretCodeTXT.Text = secretCode;
        }
    }
}





