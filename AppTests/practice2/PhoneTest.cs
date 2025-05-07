using App.practice2;

namespace AppTests.practice2;

public class PhoneTest
{
    
    [TestCase("+7-983-313-6827", "+7-983-313-6827")]
    [TestCase("перезвонить по номеру 89833136827 завтра", "89833136827")]
    [TestCase("8(983)-313-68-27", "8(983)-313-68-27")]
    [TestCase("8)983)-313-68-27", null)]
    [TestCase("8((923)004-74-06", null)]
    public void run(string str, string phone)
    {
        Phone.TryParsePhone(str, out string myPhone);
        
        if (phone != null)
            Assert.That(myPhone.Equals(phone));
        else 
            Assert.That(myPhone == null);
    }
}