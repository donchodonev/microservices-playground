﻿using GreenPipes;

using MassTransit;

using static MessageContracts.MessageContracts;

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host("localhost");
    cfg.ReceiveEndpoint("payment-service", e =>
    {
        e.Consumer<InvoiceCreatedConsumer>(c =>
        c.UseMessageRetry(m => m.Interval(5, new TimeSpan(0, 0, 10))));
    });
});

var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

await busControl.StartAsync(source.Token);

Console.WriteLine("Payment Microservice Now Listening");

try
{
    while (true)
    {
        //sit in while loop listening for messages
        await Task.Delay(100);
    }
}
finally
{
    await busControl.StopAsync();
}

class InvoiceCreatedConsumer : IConsumer<IInvoiceCreated>
{
    public Task Consume(ConsumeContext<IInvoiceCreated> context)
    {
        return Task.Run(() => Console.WriteLine($"Received message for invoice number: {context.Message.InvoiceNumber}"));
    }
}