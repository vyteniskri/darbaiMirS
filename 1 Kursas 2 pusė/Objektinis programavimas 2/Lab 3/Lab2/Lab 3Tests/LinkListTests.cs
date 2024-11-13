using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Tests
{
    [TestClass()]
    public class LinkListTests
    {
        [TestMethod()]
        public void LinkList_EmptyContainerFormsAList_ReturnFalse()
        {
            LinkList<Worker> list = new LinkList<Worker>();

            Assert.IsFalse(list.ListExist());
        }

        [TestMethod()]
        public void LinkList_EmptyContainerContainsData_ReturnFalse()
        {
            LinkList<Worker> list = new LinkList<Worker>();

            Worker worker = new Worker();
            Assert.IsFalse(list.Contains(worker));
        }

        [TestMethod()]
        public void Add_PutsOneWorkerInTheList_ReturnTrue()
        {
            LinkList<Worker> list = new LinkList<Worker>();

            Worker worker = new Worker(DateTime.MinValue, null, "Vytautas", null, 0, 0, 0, 0);
            list.Add(worker);
            
            Assert.IsTrue(list.Contains(worker));
        }

        [TestMethod()]
        public void Add_FormsAList_ReturnTrue()
        {
            LinkList<Worker> list = new LinkList<Worker>();

            Worker worker = new Worker(DateTime.MinValue, null, "Vytautas", null, 0, 0, 0, 0);
            list.Add(worker);

            Assert.IsTrue(list.ListExist());
        }

        [TestMethod()]
        public void Add_PutsTwoWorkersInTheList_ReturnTrue()
        {
            LinkList<Worker> list = new LinkList<Worker>();

            Worker worker1 = new Worker(DateTime.MinValue, null, "Vytautas", null, 0, 0, 0, 0);
            Worker worker2 = new Worker(DateTime.MinValue, null, "Nojus", null, 0, 0, 0, 0);

            list.Add(worker1);
            list.Add(worker2);
            
            Assert.IsTrue(list.Contains(worker1));
            Assert.IsTrue(list.Contains(worker2));
        }

        [TestMethod()]
        public void ListExist_EmptyListHasData_ReturnFalse()
        {
            LinkList<Worker> list = new LinkList<Worker>();

            Assert.IsFalse(list.ListExist());
        }

        [TestMethod()]
        public void ListExist_WhenListHasData_ReturnTrue()
        {
            LinkList<Worker> list = new LinkList<Worker>();
            Worker worker = new Worker();
            list.Add(worker);

            Assert.IsTrue(list.ListExist());
        }

        [TestMethod()]
        public void ListExist_TwoListsHaveData_ReturnTrue()
        {
            LinkList<Worker> list1 = new LinkList<Worker>();
            LinkList<Worker> list2 = new LinkList<Worker>();

            Worker worker = new Worker();

            list1.Add(worker);
            list2.Add(worker);

            Assert.IsTrue(list1.ListExist());
            Assert.IsTrue(list2.ListExist());
        }

        [TestMethod()]
        public void Contains_NoInformationAboutGivenData_ReturnTrue()
        {
            LinkList<Worker> list = new LinkList<Worker>();
            Worker worker1 = new Worker(DateTime.Parse("2000-07-01"), "Paulavicius", "Rokas", "ifs-0", 5, 1, 5, 6);
            Worker worker2 = new Worker(DateTime.Parse("2001-07-01"), "Jonaitis", "Rokas", "ifs-0", 5, 1, 5, 6);

            list.Add(worker2);

            Assert.IsTrue(!list.Contains(worker1));
        }

        [TestMethod()]
        public void Contains_GivenDataAboutOneWorker_ReturnTrue()
        {
            LinkList<Worker> list = new LinkList<Worker>();
            Worker worker1 = new Worker(DateTime.Parse("2000-07-01"), "Paulavicius", "Rokas", "ifs-0", 5, 1, 5, 6);
            Worker worker2 = new Worker(DateTime.Parse("2001-07-01"), "Jonaitis", "Rokas", "ifs-0", 5, 1, 5, 6);

            list.Add(worker2);

            Assert.IsTrue(list.Contains(worker2));
        }

        [TestMethod()]
        public void Contains_AllTheGivenData_ReturnTrue()
        {
            LinkList<Worker> list = new LinkList<Worker>();
            Worker worker1 = new Worker(DateTime.Parse("2000-07-01"), "Paulavicius", "Rokas", "ifs-0", 5, 1, 5, 6);
            Worker worker2 = new Worker(DateTime.Parse("2001-07-01"), "Jonaitis", "Rokas", "ifs-0", 5, 1, 5, 6);

            list.Add(worker1);
            list.Add(worker2);

            Assert.IsTrue(list.Contains(worker1));
            Assert.IsTrue(list.Contains(worker2));
        }

        [TestMethod()]
        public void Sort_TheSameInformation_ReturnFirstAddedWorkerIsFirst()
        {
            var list = new LinkList<Worker>();
            Worker worker1 = new Worker(DateTime.Parse("2000-07-01"), "Paulavicius", "Rokas", "ifs-0", 5, 1, 5, 6);
            Worker worker2 = worker1;

            list.Add(worker1);
            list.Add(worker2);
            
            Worker w = new Worker();
            list.Sort(out w);

            Assert.AreEqual(worker1.Surname, w.Surname);
        }

        [TestMethod()]
        public void Sort_DifferentInformation_ReturnSecondAddedWorkerIsFirst()
        {
            LinkList<Worker> list = new LinkList<Worker>();
            Worker worker1 = new Worker(DateTime.Parse("2000-07-01"), "Paulavicius", "Rokas", "ifs-0", 5, 1, 5, 6);
            Worker worker2 = new Worker(DateTime.Parse("2000-07-01"), "Aaulavicius", "Rokas", "ifs-0", 5, 1, 5, 6);

            list.Add(worker1);
            list.Add(worker2);

            Worker w = new Worker();
            list.Sort(out w);
            Assert.AreEqual(worker2.Surname, w.Surname);
        }

        [TestMethod()]
        public void Sort_DifferentInformation_ReturnFirstAddedWorkerIsNotFirst()
        {
            LinkList<Worker> list = new LinkList<Worker>();
            Worker worker1 = new Worker(DateTime.Parse("2000-07-01"), "Paulavicius", "Rokas", "ifs-0", 5, 1, 5, 6);
            Worker worker2 = new Worker(DateTime.Parse("2000-07-01"), "Aaulavicius", "Rokas", "ifs-0", 5, 1, 5, 6);

            list.Add(worker1);
            list.Add(worker2);

            Worker w = new Worker();
            list.Sort(out w);
            Assert.AreNotEqual(worker1.Surname, w.Surname);
        }
    }
}