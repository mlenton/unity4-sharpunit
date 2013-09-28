
using System;
using SharpUnit;
using SinglyLinkedListExample;

namespace ListUnitTest 
{ 
	public class ListTest : TestCase 
	{
	
		int[] test1array;
		SinglyLinkedList<int> test1list;
		
		int[] test2array;
		SinglyLinkedList<int> test2list;
		
		int[] test3array;
		SinglyLinkedList<int> test3list;
		
		int[] test4array;
		SinglyLinkedList<int> test4list;
		
		int[] test5array;
		SinglyLinkedList<int> test5list;
		
	 
		/** Setup test resources, called before each test. */
	    public override void SetUp() 
		{
			test1array = new int[] {0,1,2,3,4,5,6,7,8,'a'};
			test1list = new SinglyLinkedList<int>(test1array);

			test2array = new int[] {-24, 42, 8, 0, 1, -5};
			test2list = new SinglyLinkedList<int>(test2array);

			test3array = new int[] {1,2,3,4,5};
			test3list = new SinglyLinkedList<int>(test3array);

			test4array = new int[] {};
			test4list = new SinglyLinkedList<int>(test4array);

			test5array = new int[] {1,2,3};
			test5list = new SinglyLinkedList<int>(test5array);

		}
	
	    /** Dispose of test resources, called after each test */
	    public override void TearDown() 
		{
	        test1array = null;
			test1list = null;
	        test2array = null;
			test2list = null;
	        test3array = null;
			test3list = null;
	        test4array = null;
			test4list = null;
	        test5array = null;
			test5list = null;
	    }
	
	    /** Sample test that passes */
	    [UnitTest]
	    public void TestNormalOperation() 
		{
			/* 
			 * check that it works properly in normal circumstances
			 */
			Assert.Equal( 5, test1list.GetNthLast(5).data );
			Assert.Equal( 42, test2list.GetNthLast(5).data );
			Assert.Equal( 1, test3list.GetNthLast(5).data );
			Assert.Null( test4list.GetNthLast(5) );
			Assert.Null( test5list.GetNthLast(5) );
			/* 
			 * fully test one of the arrays
			 */
			int l = test1array.Length;
			for (int i=0; i<l; i++)
			{
				Assert.Equal("System.Int32", test1list.GetNthLast(l-i).data.GetType() ); 
				Assert.Equal( i, test1list.GetNthLast(l-i).data );
			}
		}
	
	    /** Sample test that fails. */
	    [UnitTest]
	    public void TestRanges() 
		{
			/* 
			 * there is no fifth-last element here, 
			 * this should return null
			 * also check that it won't cause a runtime error
			 */
			Assert.Null( test2list.GetNthLast(10) );
			
			/* 
			 * even though the exercise is only to find the fifth-last element, 
			 * test negative integers passed to the function don't cause runtime error
			 */
			Assert.Null( test2list.GetNthLast(-100) );

		}

	
	}
}


