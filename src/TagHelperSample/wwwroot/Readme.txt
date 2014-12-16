Empty file - so github can check in the folder. this folder is required otherwise running 

k  Microsoft.AspNet.Hosting --server Microsoft.AspNet.Server.WebListener --server.urls http://localhost:5001
gives the following exception.

System.IO.DirectoryNotFoundException: C:\Development\github\taghelpersample\src\TagHelperSample\wwwroot\
   at Microsoft.AspNet.FileSystems.PhysicalFileSystem..ctor(String root)
   at Microsoft.AspNet.Hosting.HostingEnvironment..ctor(IApplicationEnvironment appEnvironment, IEnumerable`1 configures
)