using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace policy_Inquiry_api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<IrquiDatabaseSettings>(
				Configuration.GetSection(nameof(IrquiDatabaseSettings)));

			services.AddSingleton<IIrquiDatabaseSettings>(sp =>
				sp.GetRequiredService<IOptions<IrquiDatabaseSettings>>().Value);

			services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
			{
				builder.AllowAnyOrigin()
					   .AllowAnyMethod()
					   .AllowAnyHeader();
			}));

			// Register the Swagger generator, defining 1 or more Swagger documents
			//services.AddSwaggerGen(c =>
			//{
			//	c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
			//});

			services.AddSingleton<PolicyInquiryService>();

			services.AddControllers().AddJsonOptions(jsonOptions =>
			{
				jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
			}).SetCompatibilityVersion(CompatibilityVersion.Version_3_0); ; ;
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			//app.UseAuthorization();

			app.UseCors("MyPolicy");

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
				
	}
		
}
