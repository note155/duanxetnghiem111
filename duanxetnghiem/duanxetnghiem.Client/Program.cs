using Append.Blazor.Printing;
using duanxetnghiem.Client;
using duanxetnghiem.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shared.ketnoi;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
builder.Services.AddScoped<IUser, UserServices>();
builder.Services.AddScoped<IBacSi, BacSiServices>();
builder.Services.AddScoped<IDonXetNghiem, DonXetNghiemServices>();
builder.Services.AddScoped<IGoiXetNghiem, GoiXetNghiemServices>();
builder.Services.AddScoped<IKetQuaXetNghiem, KetQuaXetNghiemServices>();
builder.Services.AddScoped<ITuChoi, TuChoiServices>();
builder.Services.AddScoped<IGioHang, GioHangServices>();
builder.Services.AddScoped<IThanhToan, ThanhToanServices>();
builder.Services.AddScoped<IPrintingService, PrintingService>();
builder.Services.AddScoped<IChiso, ChisoServices>();
builder.Services.AddScoped<IMau, MauServices>();
builder.Services.AddScoped<ITuvan, TuvanServices>();
builder.Services.AddScoped<IKhoa, KhoaServices>();
builder.Services.AddScoped<IPhong, PhongServices>();
builder.Services.AddScoped<IMayXetNghiem, MayXetNghiemServices>();
builder.Services.AddScoped<IRoomchat, RoomchatServices>();
builder.Services.AddScoped<IChat, ChatServices>();
builder.Services.AddScoped<ITinhtrang, TinhtrangServices>();
builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});
await builder.Build().RunAsync();
