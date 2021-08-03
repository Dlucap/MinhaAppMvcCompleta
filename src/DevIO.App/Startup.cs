using DevIO.App.Data;
using DevIO.App.Extensions;
using DevIO.Business.Interfaces;
using DevIO.Data.Context;
using DevIO.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Globalization;

namespace DevIO.App
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

      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(
              Configuration.GetConnectionString("DefaultConnection")));

      services.AddDbContext<MeuDbContext>(options =>
          options.UseSqlServer(
              Configuration.GetConnectionString("DefaultConnection")));
      services.AddDatabaseDeveloperPageExceptionFilter();

      services.AddDefaultIdentity<IdentityUser>(/*options => options.SignIn.RequireConfirmedAccount = true*/)
        // .AddDefaultUI(Microsoft.AspNetCore.Identity.UI.UIFramework.Bootstrap4) //Microsoft.AspNetCore.Identity.UI
        .AddEntityFrameworkStores<ApplicationDbContext>();


      /// services.AddControllersWithViews();

      services.AddAutoMapper(typeof(Startup));

      services.AddMvc(options =>
      {
        options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => "O valor preenchido � inv�lido para este campo.");
        options.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(x => "Este campo precisa ser preenchido.");
        options.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => "Este campo precisa ser preenchido.");
        options.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() => "� necess�rio que o body na requisi��o n�o esteja vazio.");
        options.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor((x) => "O valor preenchido � inv�lido para este campo.");
        options.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() => "O campo deve ser n�merico.");
        options.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() => "O valor preenchido � inv�lido para este campo.");
        options.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor((x) => "O valor preenchido � inv�lido para este campo.");
        options.ModelBindingMessageProvider.SetValueIsInvalidAccessor((x) => "O valor preenchido � inv�lido para este campo.");
        options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(x => "O campo deve ser num�rico.");
        options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => "Este campo deve ser preenchido.");

      })
      .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

           //Resolvendo as inje��es de depend�ncias
      services.AddScoped<MeuDbContext>();
      services.AddScoped<IProdutoRepository, ProdutoRepository>(); 
      services.AddScoped<IFornecedorRepository, FornecedorRepository>();  
      services.AddScoped<IEnderecoRepository, EnderecoRepository>();

      //Inje��o de depend�ncia do AdapterProvider de validation
      services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseMigrationsEndPoint();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }
      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCookiePolicy();
      
      #region[Globalization]
      var defaultCulture = new CultureInfo("pt-BR");
      var localizationOptions = new RequestLocalizationOptions
      {
        DefaultRequestCulture = new RequestCulture(defaultCulture),
        SupportedCultures = new List<CultureInfo> { defaultCulture },
        SupportedUICultures = new List<CultureInfo> { defaultCulture }
      };
      app.UseRequestLocalization(localizationOptions);
      #endregion
      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapRazorPages();
      });
    }
  }
}
