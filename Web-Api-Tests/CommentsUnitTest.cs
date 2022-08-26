//using Microsoft.AspNetCore.Mvc;
//using MoviesProj.Controllers;
//using MoviesProj.Models.Comment;
//using MoviesProj.Services;

//namespace Web_Api_Tests
//{
//    public class CommentsControllerTest
//    {
//        private readonly CommentsController _controller;
//        private readonly ICommentService _service;

//        public CommentsControllerTest()
//        {
//            _service = new CommentServiceFake();
//            _controller = new CommentsController(_service);
//        }

//        [Fact]
//        public void Index_WhenCalled_ReturnsOkResult()
//        {
//            // Act
//            var okResult = _controller.Index();

//            // Assert
//            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
//        }

//        [Fact]
//        public void Index_WhenCalled_ReturnsAllItems()
//        {
//            // Act
//            var okResult = _controller.Index() as OkObjectResult;

//            // Assert
//            var items = Assert.IsType<List<Comment>>(okResult.Value);
//            Assert.Equal(3, items.Count);
//        }
//        [Fact]
//        public void Details_WhenCalled_ReturnsOkResult()
//        {
//            //Arrange
//            var testId = "5a9427648b0beebeb6957a21";
//            //Act
//            var okResult = _controller.Details(testId);
//            //Assert
//            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
//        }
//        [Fact]
//        public void Details_WhenCalled_ReturnsRightItem()
//        {
//            //Arrange
//            var testId = "5a9427648b0beebeb6957a21";
//            //Act
//            var okResult = _controller.Details(testId) as OkObjectResult;
//            //Assert
//            Assert.IsType<Comment>(okResult.Value);
//            Assert.Equal(testId, (okResult.Value as Comment).Id);
//        }
//        [Fact]
//        public void Details_UnkownIdPassed_ReturnsNotFoundResult()
//        {
//            //Arrange
//            var testId = "6b2334456b0beebfd6932c28";
//            //Act
//            var notFoundObjectResult = _controller.Details(testId);
//            //Assert
//            Assert.IsType<NotFoundObjectResult>(notFoundObjectResult);
//        }

//        [Fact]
//        public void Create_InvalidObjectPassed_ReturnsBadRequest()
//        {
//            // Arrange
//            var movieIdMissingItem = new Comment()
//            {
//                Id = "5a9427648b0beebeb6957b1a",
//                Name = "Doreah",
//                Email = "roxanne_mckee@gameofthron.es",
//                //MovieId = "573a1391f29313caabcd7850",
//                Text = "Nulla assumenda corporis a impedit. Ratione voluptates veritatis dolorem quod officiis minima. Labore dolor repudiandae voluptatum nam. Dignissimos quo sit sint sint labore similique.",
//                Date = DateTime.UtcNow
//            };
//            _controller.ModelState.AddModelError("MovieId", "Required");

//            // Act
//            var badResponse = _controller.Create(movieIdMissingItem);

//            // Assert
//            Assert.IsType<BadRequestObjectResult>(badResponse);
//        }

//        [Fact]
//        public void Create_ValidObjectPassed_ReturnsCreatedResponse()
//        {
//            // Arrange
//            var testItem = new Comment()
//            {
//                Id = "5a9427648b0beebeb6957b1a",
//                Name = "Doreah",
//                Email = "roxanne_mckee@gameofthron.es",
//                MovieId = "573a1391f29313caabcd7850",
//                Text = "Nulla assumenda corporis a impedit. Ratione voluptates veritatis dolorem quod officiis minima. Labore dolor repudiandae voluptatum nam. Dignissimos quo sit sint sint labore similique.",
//                Date = DateTime.UtcNow
//            };

//            // Act
//            var createdResponse = _controller.Create(testItem);

//            // Assert
//            Assert.IsType<OkObjectResult>(createdResponse);
//        }

//        [Fact]
//        public void Create_ValidObjectPassed_ReturnedResponseHasCreatedItem()
//        {
//            // Arrange
//            var testItem = new Comment()
//            {
//                Id = "5a9427648b0beebeb6957b1a",
//                Name = "Doreah",
//                Email = "roxanne_mckee@gameofthron.es",
//                MovieId = "573a1391f29313caabcd7850",
//                Text = "Nulla assumenda corporis a impedit. Ratione voluptates veritatis dolorem quod officiis minima. Labore dolor repudiandae voluptatum nam. Dignissimos quo sit sint sint labore similique.",
//                Date = DateTime.UtcNow
//            };

//            // Act
//            var createdResponse = _controller.Create(testItem) as OkObjectResult ;
//            var item = createdResponse.Value as Comment;

//            // Assert
//            Assert.IsType<Comment>(item);
//            Assert.Equal("Doreah", item.Name);
//        }

//        [Fact]
//        public void Edit_ExistingCommentPassed_ReturnsNotFoundResponse()
//        {
//            // Arrange
//            var notExistingId = "5a9427648b0beebeb6957b51";
//            var comment = new Comment()
//            {
//                Id = "5a9427648b0beebeb6957b51",
//                Name = "Alliser Thorne",
//                Email = "owen_teale@gameofthron.es",
//                MovieId = "573a1391f29313caabcd7c9e",
//                Text = "A ut dolor illum deleniti repellendus. Iste fugit in quas minus nobis sunt rem. Animi possimus dolor alias natus consequatur saepe. Nihil quam magni aspernatur nisi.",
//                Date = DateTime.UtcNow
//            };

//            // Act
//            var badResponse = _controller.Edit(notExistingId,comment);

//            // Assert
//            Assert.IsType<NotFoundObjectResult>(badResponse);
//        }
//        [Fact]
//        public void Edit_InvalidObjectPassed_ReturnsBadRequest()
//        {
//            // Arrange
//            var Id = "5a9427648b0beebeb6957a21";
//            var nameMissingItem = new Comment()
//            {
//                Id = "5a9427648b0beebeb6957a21",
//                Name = "Alliser Thorne",
//                Email = "owen_teale@gameofthron.es",
//                //MovieId = "573a1391f29313caabcd7c9e",
//                Text = "A ut dolor illum deleniti repellendus. Iste fugit in quas minus nobis sunt rem. Animi possimus dolor alias natus consequatur saepe. Nihil quam magni aspernatur nisi.",
//                Date = DateTime.UtcNow
//            };

//            // Act
//            var badResponse = _controller.Edit(Id,nameMissingItem);

//            // Assert
//            Assert.IsType<BadRequestObjectResult>(badResponse);
//        }
//        [Fact]
//        public void Edit_ValidObjectPassed_ReturnsOkResponse()
//        {
//            // Arrange
//            var Id = "5a9427648b0beebeb6957a21";
//            var testItem = new Comment()
//            {
//                Id = "5a9427648b0beebeb6957a21",
//                Name = "Alliser Thorne",
//                Email = "owen_teale@gameofthron.es",
//                MovieId = "573a1391f29313caabcd7c9e",
//                Text = "A ut dolor illum deleniti repellendus. Iste fugit in quas minus nobis sunt rem. Animi possimus dolor alias natus consequatur saepe. Nihil quam magni aspernatur nisi.",
//                Date = DateTime.UtcNow
//            };

//            // Act
//            var updatedResponse = _controller.Edit(Id,testItem);

//            // Assert
//            Assert.IsType<OkObjectResult>(updatedResponse);
//        }

//        [Fact]
//        public void Edit_ValidObjectPassed_ReturnedResponseHasUpdatedItem()
//        {
//            // Arrange
//            var Id = "5a9427648b0beebeb6957a21";
//            var testItem = new Comment()
//            {
//                Id = "5a9427648b0beebeb6957a21",
//                Name = "Alliser Thorne",
//                Email = "owen_teale@gameofthron.es",
//                MovieId = "573a1391f29313caabcd7c9e",
//                Text = "A ut dolor illum deleniti repellendus. Iste fugit in quas minus nobis sunt rem. Animi possimus dolor alias natus consequatur saepe. Nihil quam magni aspernatur nisi.",
//                Date = DateTime.UtcNow
//            };

//            // Act
//            var updatedResponse = _controller.Edit(Id,testItem) as OkObjectResult;
//            var item = updatedResponse.Value as Comment;

//            // Assert
//            Assert.IsType<Comment>(item);
//            Assert.Equal("Alliser Thorne", item.Name);
//            Assert.Equal("owen_teale@gameofthron.es", item.Email);
//            Assert.Equal("573a1391f29313caabcd7c9e", item.MovieId);
//            Assert.Equal("A ut dolor illum deleniti repellendus. Iste fugit in quas minus nobis sunt rem. Animi possimus dolor alias natus consequatur saepe. Nihil quam magni aspernatur nisi.", item.Text);
//        }
//        [Fact]
//        public void Delete_NotExistingIdPassed_ReturnsNotFoundResponse()
//        {
//            // Arrange
//            var notExistingId = "5a9427648b0beebeb6957b51";

//            // Act
//            var badResponse = _controller.Delete(notExistingId);

//            // Assert
//            Assert.IsType<NotFoundObjectResult>(badResponse);
//        }

//        [Fact]
//        public void Delete_ExistingIdPassed_ReturnsNoContentResult()
//        {
//            // Arrange
//            var existingId = "5a9427648b0beebeb6957a21";

//            // Act
//            var OkObjectResponse = _controller.Delete(existingId);

//            // Assert
//            Assert.IsType<OkObjectResult>(OkObjectResponse);
//        }

//        [Fact]
//        public void Delete_ExistingIdPassed_RemovesOneItem()
//        {
//            // Arrange
//            var existingId = "5a9427648b0beebeb6957a21";

//            // Act
//            _controller.Delete(existingId);

//            // Assert
//            Assert.Equal(2, _service.Get().Count);
//        }
//    }
//}