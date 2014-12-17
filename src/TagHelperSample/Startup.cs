using System;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;

namespace TagHelperSample
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseServices(m => { m.AddMvc(); });
            app.UseMvc();

      
        }
    }
}
