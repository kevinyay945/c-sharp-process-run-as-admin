using System;
using System.Diagnostics;
using System.Text;

namespace TestProject2
{
    public class NssmProcess
    {
        private readonly string _nssmPath;

        public NssmProcess(string nssmPath)
        {
            if (nssmPath==null || nssmPath=="")
            {
                throw new Exception("can't get nssm.exe when initial");
            }

            this._nssmPath = nssmPath;
        }

        public string Exec(string cmd)
        {
            var process = new Process();
            var stringBuilder = new StringBuilder();
            var processStartInfo = new ProcessStartInfo();
            processStartInfo.CreateNoWindow = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.Verb = "runas";
            processStartInfo.Arguments = cmd;
            processStartInfo.FileName = this._nssmPath;
            process.StartInfo = processStartInfo;
            process.EnableRaisingEvents = true;
            process.OutputDataReceived += new DataReceivedEventHandler
            (
                delegate(object sender, DataReceivedEventArgs e)
                {
                    // append the new data to the data already read-in
                    stringBuilder.Append(e.Data);
                }
            );
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
            process.CancelOutputRead();
            return stringBuilder.ToString();
        }
    }
}