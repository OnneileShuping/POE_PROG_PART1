namespace POE_PROG_PART1
{
    //import system.media
    using System.Media;
    using System;
    using System.IO;

    public class voice_greeting
    {

        //constructor
        public voice_greeting()
        {
            //now get where the project is
            string full_location = AppDomain.CurrentDomain.BaseDirectory;

            //now lets replace the bin\Debug\ so it can get the audio
            string new_path = full_location.Replace("bin\\Debug\\", "");

            //try and catch
            try
            {
                //combine the paths
                string full_path = Path.Combine(new_path, "greeting.wav");

                //now we create instance for the SoundPlay class
                using (SoundPlayer play = new SoundPlayer(full_path))
                {

                    //play the file
                    play.PlaySync();

                }//end of using
            }
            catch (Exception error)
            {
                Console.Write(error.Message);

            }//end of catch

        }//end of constructor


    }//end of class
}//end of namespace