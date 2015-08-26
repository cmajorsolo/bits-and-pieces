/*
Version 1.0
 * This is a test class that tests method Flat() in Class Flatten.FlattenAnArray
*/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Flatten;

namespace FlattenTest
{
    [TestClass]
    public class FlattenAnArrayTest
    {
        //if input is null, result should be null as well.
        [TestMethod]
        public void FlatMethodTestNull()
        {
            Assert.IsNull(FlattenAnArray.Flat(null));
        }

        //if input is an empty list, the result shoudl be an empty list as well.
        [TestMethod]
        public void FlatMethodTestEmpty()
        {
           ArrayList initList = new ArrayList();
           ArrayList resultList = FlattenAnArray.Flat(initList);
           Assert.IsTrue(initList.Count == resultList.Count);
        }

        //if input is flat list, the result list should be a same flat list.
        [TestMethod]
        public void FlatMethodTestFlatList()
        {
            ArrayList initList = new ArrayList { 1, 2, 3, 4, 5};
            ArrayList resultList = FlattenAnArray.Flat(initList);
            Assert.IsTrue(TestEqual(initList, resultList));
        }

        //if input is a nested list, the result should be flat list
        [TestMethod]
        public void FlatMethodTestNestedList()
        {
            ArrayList initList = new ArrayList { new ArrayList {1, new ArrayList {2,3,4 }},5,6, new ArrayList {7}, new ArrayList { new ArrayList {8,9},10}};
            ArrayList resultList = FlattenAnArray.Flat(initList);
            ArrayList correctResultList = new ArrayList {1,2,3,4,5,6,7,8,9,10 };
            Assert.IsTrue(TestEqual(correctResultList, resultList));
        }

        //if input is a nested list with empty list element, the result should contains no empty element. 
        [TestMethod]
        public void FlatMethodTestNestedListWithEmptyList()
        {
            ArrayList initList = new ArrayList { new ArrayList { 1, new ArrayList { 2, 3, 4 } }, 5, 6, new ArrayList { 7 }, new ArrayList { }, new ArrayList { new ArrayList { 8, 9 }, 10 , new ArrayList{}} };
            ArrayList resultList = FlattenAnArray.Flat(initList);
            ArrayList correctResultList = new ArrayList { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Assert.IsTrue(TestEqual(correctResultList, resultList));
        }

        //This method compares two list
        // return true when the content of two lists are same. 
        public bool TestEqual(ArrayList initList,ArrayList resultList)
        {
            if (initList.Count != resultList.Count)
                return false;
            else
            {
                for (int i = 0; i < initList.Count; i++)
                {
                    if (initList[i].ToString() != resultList[i].ToString())
                        return false;
                }
                return true;
            }
        }

    }
}
