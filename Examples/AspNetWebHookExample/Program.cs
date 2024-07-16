using AspNetWebHook;
using AspNetWebHook.Controllers;
using AspNetWebHook.Services;
using PRTelegramBot.Core;
using PRTelegramBot.Core.Factory;

/****************************************************************************************
 * ######################################################################################
 * 
 * ���������� ������������ https://prethink.gitbook.io/prtelegrambot
 * 
 * ######################################################################################
 ****************************************************************************************/

var builder = WebApplication.CreateBuilder(args);

//��� ������ webhook ����� ����������� � newtonsoftJson!!!
builder.Services.AddControllers().AddNewtonsoftJson();

#region ��������� �����

new PRBotBuilder("5623652365:Token")
    .UseFactory(new PRBotWebHookFactory())
    .SetUrlWebHook("https://domain.ru/botendpoint")
    .SetClearUpdatesOnStart(true)
    .Build();

new PRBotBuilder("555555:Token")
    .UseFactory(new PRBotWebHookFactory())
    .SetUrlWebHook("https://domain.ru/botendpoint")
    .SetClearUpdatesOnStart(true)
    .SetBotId(1)
    .Build();

// ����� ���������� ���� ����� ����� ����� ����� BotCollection

#endregion

#region ������ ������� �����

builder.Services.AddHostedService<BotHostedService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#region �������� �������� ��� webhook

app.MapBotWebhookRoute<BotController>("/botendpoint");
app.MapControllers();

#endregion

app.Run();