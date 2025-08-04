// <copyright file="EventBuilderService.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Event;

using Yunhu.Api;
using Yunhu.Transfer;

public class EventBuilderService
{
    private readonly Dictionary<BuilderManifest, BuildEvent> builders = new Dictionary<BuilderManifest, BuildEvent>();

    public EventBuilderService()
    {
        this.Register(new UserBuilder());
        this.Register(new ChatBuilder());
        this.Register(new MessageBuilder());
        this.Register(new MessageContextBuilder());
        this.Register<CommandMessage, CommandMessageTransfer>(new CommandMessageBuilder());
        this.Register(new CommandContextBuilder());
        this.Register(new ShortcutContextBuilder());
        this.Register(new HeaderBuilder());
    }

    private delegate object BuildEvent(ITransfer transfer);

    public static EventBuilderService Instance { get; } = new EventBuilderService();

    public T Build<T, TE>(ITransfer transfer)
        where TE : ITransfer
    {
        var manifest = new BuilderManifest(typeof(T), typeof(TE));

        if (!this.builders.TryGetValue(manifest, out var buildEvent))
        {
            throw new InvalidOperationException("Manifest not registered: " + manifest);
        }

        return (T)buildEvent(transfer);
    }

    public void Register<T, TE>(IEventBuilder<T, TE> builder)
        where TE : ITransfer
    {
        var manifest = new BuilderManifest(typeof(T), typeof(TE));
        this.builders[manifest] = PackedBuilder;

        return;

        object PackedBuilder(ITransfer transfer)
        {
            return builder.Build((TE)transfer) ?? throw new InvalidOperationException();
        }
    }

    private readonly record struct BuilderManifest(Type EventDataType, Type TransferDataType);
}