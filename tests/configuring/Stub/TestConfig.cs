using System;
using ByteBee.Framework.Configuring.Abstractions.DataClasses;

namespace ByteBee.Framework.Tests.Configuring.Stub
{
    [ConfigSection("test")]
    public sealed class TestConfig
    {
        [ConfigKey("string", IgnoreNull = true)]
        public string StringValue { get; set; }
        
        [ConfigKey("int")]
        public int IntValue { get; set; }
        
        [ConfigKey("double")]
        public double DoubleValue { get; set; }
        
        [ConfigKey("bool")]
        public bool BoolValue { get; set; }
        
        [ConfigKey("uri")]
        public Uri UriValue { get; set; }
    }
}