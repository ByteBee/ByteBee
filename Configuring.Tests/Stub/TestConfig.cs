using System;
using ByteBee.Framework.Configuring.Contract.DataClasses;

namespace ByteBee.Configurating.Tests.Stub
{
    [ConfigSection("test")]
    public class TestConfig
    {
        [ConfigKey("sting", IgnoreNull = true)]
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