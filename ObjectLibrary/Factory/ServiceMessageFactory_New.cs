﻿using System;
using System.Diagnostics;
using ObjectLibrary.Messaging.Base;

namespace ObjectLibrary.Factory
{
    public static class ServiceMessageFactory_New<T> where T : IServiceMessage, new()
    {

        public static T Create()
        {
            return Create(Guid.Empty);
        }

        public static T Create(Guid correlationId)
        {
            var instance = new T
            {
                MessageId = Guid.NewGuid(),
                CorrelationId = correlationId,
                Timestamp = DateTime.UtcNow,
                Stopwatch = Stopwatch.StartNew()
            };
            return instance;
        }

        public static T CreateFrom(IServiceMessage caller)
        {

            var message = Create();
            message.CorrelationId = caller.CorrelationId == Guid.Empty
                ? caller.MessageId
                : caller.CorrelationId;
            return message;

        }

    }
}