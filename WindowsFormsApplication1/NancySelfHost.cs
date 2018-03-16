using System;
using System.Collections.Generic;
using WindowsFormsApplication1.Searches;
using Nancy.Hosting.Self;
using Nancy.ViewEngines.Razor;
using Nancy;

namespace WindowsFormsApplication1
{
    public class NancySelfHost
    {
        private NancyHost m_nancyHost;
        private string _url = "http://localhost";
        private int _port = 666;
        public void Start()
        {
            HostConfiguration hostConfigs = new HostConfiguration();
hostConfigs.UrlReservations.CreateAutomatically = true;
            var uri = new Uri($"{_url}:{_port}/");
            var configuration = new HostConfiguration() { UrlReservations = new UrlReservations() { CreateAutomatically = true } };


            NancyHost nancyHost = new NancyHost(configuration, uri);
            Console.WriteLine("Started!");
            nancyHost.Start();
        }

        public void Stop()
        {
            m_nancyHost.Stop();
            Console.WriteLine("Stopped. Good bye!");
        }
    }
    public class RazorConfiguration : IRazorConfiguration
    {
        public bool AutoIncludeModelNamespace => false;

        public IEnumerable<string> GetAssemblyNames()
        {
            yield return "ThugByte";

        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            yield return "WindowsFormsApplication1";
     
        }
    }
    public class SimpleModule : Nancy.NancyModule
    {
        
        public SimpleModule()
        {
         Myfreemp3 ser = new Myfreemp3(true);

            Get["/"] = parameters => Response.AsRedirect("/s1");

            Get["/s1"] = _ => View["Views/index.cshtml",ser.SearchAsync("",0,0)];

            Get["/s1/{search}"] = parameters => View["Views/index.cshtml", ser.SearchAsync(parameters.search, 0,0)]; 
          
        }
    }
    public class Mp3pmWeb : Nancy.NancyModule
    {

        public Mp3pmWeb()
        {
            Mp3pm ser = new Mp3pm(true);

            Get["/s3"] = _ => View["Views/index.cshtml", ser.SearchAsync("", 0,0)];

            Get["/s3/{search}"] = parameters => View["Views/index.cshtml", ser.SearchAsync(parameters.search, 0,0)];

        }
    }
}
