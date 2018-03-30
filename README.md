## This project test for AdminLTE v.2.4.3


$> dotnet new sln
$> dotnet new web -o LabFix.AdminLte
$> dotnet sln add LabFix.AdminLte/LabFix.AdminLte.csproj
$> cd LabFix.AdminLte
$> dotnet build

# create foder Controllers , Views/Home , View/Shared
$> mkdir Controllers Views
$> mkdir -p Views/Home Views/Shared
$> touch Controllers/HomeController.cs


# create file
$> touch Views/Home/Index.cshtml
$> touch Views/Shared/_Layout.cshtml

# Copy folder
Download AdminLTE : https://adminlte.io/
“bower_componets , dist”  from "AdminLTE.zip" ==> to ==> wwwroot

## EDIT File ----------------------------------------

$> vi Controllers/HomeController.cs

using Microsoft.AspNetCore.Mvc;

namespace AdminLTE.WebUI.Controllers
{
   public class HomeController : Controller
   {
       public IActionResult Index()
       {
           return View();
       }
   }
}

## EDIT Startup --------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AdminLTE.WebUI
{
   public class Startup
   {
       public void ConfigureServices(IServiceCollection services)
       {
           services.AddMvc();
       }

       public void Configure(IApplicationBuilder app, IHostingEnvironment env)
       {
           if (env.IsDevelopment())
           {
               app.UseDeveloperExceptionPage();
           }

           app.UseMvc(routes=>{
               routes.MapRoute(
                   name:"default",
                   template:"{controller=Home}/{action=Index}/{id?}"
               );

           });

           app.UseStaticFiles();
       }
   }
}

## Edit _Layout.cshtml

Copy content from AdminLTE.zip

/AdminLTE-2.4.3/pages/examples/blank.html ==>  /Shared/_Layout.cshtml


in _Layout.cshtml

move all style & script to
<environment include="Development">
   ........
   And change "../../" to "~"
</environment>
Complete code as below

# Style ----------------------------------

 <environment include="Development">
   <link rel="stylesheet" href="~/bower_components/bootstrap/dist/css/bootstrap.min.css">
   <!-- Font Awesome -->
   <link rel="stylesheet" href="~/bower_components/font-awesome/css/font-awesome.min.css">
   <!-- Ionicons -->
   <link rel="stylesheet" href="~/bower_components/Ionicons/css/ionicons.min.css">
   <!-- Theme style -->
   <link rel="stylesheet" href="~/dist/css/AdminLTE.min.css">
   <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
   <link rel="stylesheet" href="~/dist/css/skins/_all-skins.min.css">
 </environment>

 # Script ----------------------------------

 <environment include="Development">
   <!-- jQuery 3 -->
   <script src="~/bower_components/jquery/dist/jquery.min.js"></script>
   <!-- Bootstrap 3.3.7 -->
   <script src="~/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
   <!-- SlimScroll -->
   <script src="~/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
   <!-- FastClick -->
   <script src="~/bower_components/fastclick/lib/fastclick.js"></script>
   <!-- AdminLTE App -->
   <script src="~/dist/js/adminlte.min.js"></script>
   <!-- AdminLTE for demo purposes -->
   <script src="~/dist/js/demo.js"></script>

</environment>


## -- Cut And move content -----------------------------------------------
<!-- Main content -->
<section class="content">
......
</section>
<!-- /.content -->

into ====> "index.cshtmml

And

<!-- Main content -->
@RenderBody()
<!-- /.content -->


## index.cshtml -----------------------------------------------

Add line at header

@{
   Layout = "_Layout";
}
