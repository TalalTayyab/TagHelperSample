using System;
using System.Globalization;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using TagHelperSample.Model;

namespace TagHelperSample
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
           
            app.UseServices(m => { m.AddMvc(); });
            app.UseMvc();

            populateSampleData();

        }

        void populateSampleData()
        {
            Person.Persons.Add(new Person()
            {
                Name = "Person 1",
                Email = "first.last@email.com",
                Birthday = DateTime.ParseExact("18/07/14", "dd/MM/yy", CultureInfo.InvariantCulture),
                Country = "AU"
            });

            Person.Persons.Add(new Person()
            {
                Name = "Person 2",
                Email = "last.first@email.com",
                Birthday = DateTime.ParseExact("18/07/14", "dd/MM/yy", CultureInfo.InvariantCulture),
                Country = "*"
            });
        }
    }
}
