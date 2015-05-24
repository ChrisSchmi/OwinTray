OwinTray
====

I just wanted to know, if I could run a self hosted MVC WebAPI in a DLL, because all official MS examples only demonstrate working with console apps.

This repository keeps three subprojects:

- ApiHostLibrary: a DLL which hosts configures and starts the WebAPI
- ApiTestClient: small console program to query the API
- OwinTray: a Windows Forms App which hosts an instance of the API

Further information about OWIN, MVC WebAPI etc:

[http://www.asp.net/web-api/overview/releases/whats-new-in-aspnet-web-api-22](http://www.asp.net/web-api/overview/releases/whats-new-in-aspnet-web-api-22)
[http://www.asp.net/web-api/overview/hosting-aspnet-web-api/use-owin-to-self-host-web-api](http://www.asp.net/web-api/overview/hosting-aspnet-web-api/use-owin-to-self-host-web-api)
