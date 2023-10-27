using Serilog;
using Serilog.Events;
using Serilog.Sinks;
using Microsoft.Extensions.Logging;

static void Main(string[] args)
{
    // Configurar o logger do Serilog
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();

    // Configurar o LoggerFactory para usar o Serilog
    var loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddSerilog();
    });

    var logger = loggerFactory.CreateLogger<Program>();

    // Agora você pode usar o logger para capturar mensagens de log
    logger.LogInformation("Aplicação Worker iniciada.");

    // Execute sua lógica de aplicativo Worker aqui

    logger.LogInformation("Aplicação Worker concluída.");

    // Certifique-se de fechar e liberar os recursos do logger
    Log.CloseAndFlush();
    
}

