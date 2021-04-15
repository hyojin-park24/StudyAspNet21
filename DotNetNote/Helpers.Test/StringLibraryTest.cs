using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Helpers.Test
{
    [TestClass]
    public class StringLibraryTest
    {
        [TestMethod]
        public void CutStringTest()
        {
            string strCut = "Hello World, This is a test sentence";
            int intChar = 15;

            var expected = "Hello World,..."; //CutString예상값
            var actual = StringLibrary.CutString(strCut, intChar);
            Assert.AreEqual(expected, actual); // 값이 같은지 비교하는 형식
        }

        [TestMethod]
        public void CutStringUnicodeTest()
        {
            string strCut = "안녕하세요, 부경대학교입니다.";
            int intChar = 9;

            var expected = "안녕하세요,...";
            var actual = StringLibrary.CutStringUnicode(strCut, intChar);
            Assert.AreEqual(expected, actual);
        }

        //[Ignore] 테스팅에서 제외
        [TestMethod]
        public void AddTest()
        {
            var expected = 10;
            var actual = (5 + 5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsPhotoTest()
        {
            var imagePath = @"D:\GitRepository\StudyDesktopApp\Source\32.png";
            bool result = BoardLibrary.IsPhoto(imagePath); //결과가 돌아옴 true/false로
            Assert.IsTrue(result, "file extension must be png, jpg, gif");
        }

        [TestMethod]
        public void IsNotPhotoTest()
        {
            var imagePath = @"D:\GitRepository\StudyDesktopApp\Source\32.pdf";
            bool result = BoardLibrary.IsPhoto(imagePath); //결과가 돌아옴 true/false로
            Assert.IsFalse(result, "file extension must be png, jpg, gif");
        }
    }
}
