using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Domain;
using NHibernate.Burrow;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Ploeh.AutoFixture;

namespace DomainTest
{
    [TestFixture]
    public class UserTest
    {
        private Fixture _fixture;
        private User _user;
        private Role _role;
        private UserRepository _userRepository=new UserRepository();
        private RoleRepository _roleRepository=new RoleRepository();
        private BurrowFramework _burrow=new BurrowFramework();
        private UserRoleLink _userRoleLink;
        private UserRoleLinkRepository _userRoleLinkRepository = new UserRoleLinkRepository();

        [SetUp]
        public void SetUp()
        {
            _burrow.InitWorkSpace();
        }
        [Test]
        public void CreateUser()
        {
            
            _fixture = new Fixture();
           
            _role = new Role {Name = _fixture.Create<string>()};

            _roleRepository.Save(_role);
            _user = new User {Name = _fixture.Create<string>()};
         
            _userRepository.Save(_user);

            _userRoleLink = new UserRoleLink(_user,_role);
            _userRoleLinkRepository.Save(_userRoleLink);
           _burrow.CloseWorkSpace();
            _burrow.InitWorkSpace();
           
            Assert.AreEqual(_userRepository.FindByRoleId(_role.Id).ToList().First(), _user);
        }
        [TearDown]
        public void TearDown()
        {
            _userRoleLink = _userRoleLinkRepository.Get(_userRoleLink.Id);
                _userRoleLinkRepository.Delete(_userRoleLink);
            _user = _userRepository.Get(_user.Id);
            _userRepository.Delete(_user);

            _role = _roleRepository.Get(_role.Id);
                _roleRepository.Delete(_role);
            _burrow.CloseWorkSpace();
        }
    }
}
