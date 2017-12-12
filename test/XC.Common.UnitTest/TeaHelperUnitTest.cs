using System;
using System.Text;
using XC.Common.Encrypt;
using XC.Common.String;
using Xunit;

namespace XC.Common.UnitTest
{
	
    public class TeaHelperUnitTest
    {
        [Fact]
        public void TeaEncrypt()
        {
	        byte[] key = Encoding.UTF8.GetBytes("1231231231232125");
	        byte[] data = Encoding.UTF8.GetBytes("I like dog and cat.");
	        var encryptData = TeaHelper.Encrypt(data, key);
	        var decryptData = TeaHelper.Decrypt(encryptData, key);

	        string data1 = data.ToBase64String();
	        string data2 = decryptData.ToBase64String();
			Assert.Equal(data1, data2);
        }

	    [Fact]
	    public void XXTeaEncrypt()
	    {
		    byte[] key = Encoding.UTF8.GetBytes("abcdefg");
		    byte[] data = Encoding.UTF8.GetBytes("I like dog and cat.");
		    var encryptData = XXTeaHelper.Encrypt(data, key);
		    var decryptData = XXTeaHelper.Decrypt(encryptData, key);

		    string data1 = data.ToBase64String();
		    string data2 = decryptData.ToBase64String();
		    Assert.Equal(data1, data2);
	    }
	}
}
