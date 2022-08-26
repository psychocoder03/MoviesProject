//using Moq;
//using MoviesProj.Controllers;
//using MoviesProj.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Web_Api_Tests
//{
//    public class SpecificCommentsControllerTests
//    {
//        private readonly Mock<ISpecificCommentService> _mockRepo;
//        private readonly SpecificCommentsController _controller;
//        public SpecificCommentsControllerTests()
//        {
//            _mockRepo = new Mock<ISpecificCommentService>();
//            _controller = new SpecificCommentsController(_mockRepo.Object);
//        }

//        //[Fact]
//        //public void Get_EmailPassed_ReturnsAllEmailSpecificComments()
//        //{
//        //    var email = "test@example.com"
//        //    var result = _controller.EmailSpecComment(email);
//        //    Assert.IsType<ViewResult>(result);
//        //}
//    }
//}
