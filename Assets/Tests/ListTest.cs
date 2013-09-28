
using System;
using SharpUnit;
using SinglyLinkedListExample;

namespace ListUnitTest 
{ 
	public class ListTest : TestCase 
	{
		/** declarations for the test subjects */
		SinglyLinkedList<int> test1list;
		SinglyLinkedList<int> test2list;
		SinglyLinkedList<int> test3list;
		SinglyLinkedList<int> test4list;		
		SinglyLinkedList<int> test5list;
			 
		/** Setup test resources, called before each test. */
	    public override void SetUp() 
		{
			
			/** an array of positive integers */
//			test1list = new SinglyLinkedList<int>(new int[] {0,1,2,3,4,5,6,7,8,9});
			test1list = new SinglyLinkedList<int>();
			test1list.Append(1);
			test1list.Append(1);
			test1list.Append(2);
			test1list.Append(3);
			test1list.Append(4);
			test1list.Append(5);
			test1list.Append(6);
			test1list.Append(7);
			test1list.Append(8);
			test1list.Append(9);

			/** an array containing negative integers */
			test2list = new SinglyLinkedList<int>(new int[] {-24, 42, 8, 0, 1, -5});

			/** an array of length 5, also containing negative integers */
			test3list = new SinglyLinkedList<int>(new int[] {-1,-2,-3,-4,-5});

			/** an array of length zero */
			test4list = new SinglyLinkedList<int>(new int[] {});

			/** an array containing less than 5 integers */
			test5list = new SinglyLinkedList<int>(new int[] {1,2,3});

			/* todo: ensure using new int[] in cstr parameter in this way does not cause memory leak 
			 * done as such for brevity & readability, for the purposes of this exercise 
			 */
		}
	
	    /** Dispose of test resources, called after each test */
	    public override void TearDown() 
		{
			test1list = null;
			test2list = null;
			test3list = null;
			test4list = null;
			test5list = null;
	    }
	
		/** test the 'fifth-last' cases for each of the test lists */
	    [UnitTest]
	    public void TestList1_5thLast() 
		{
			/** ensure the correct value is returned */
			Assert.Equal( 5, test1list.GetNthLast(5).data );
		}
		
	    [UnitTest]
	    public void TestList2_5thLast() 
		{
			/** ensure the correct value is returned */
			Assert.Equal( 42, test2list.GetNthLast(5).data );
		}
		
	    [UnitTest]
	    public void TestList3_5thLast() 
		{
			/** ensure the correct value is returned */
			Assert.Equal( -1, test3list.GetNthLast(5).data );
		}
		
	    [UnitTest]
	    public void TestList4_5thLast() 
		{
			/** ensure it won't cause a runtime error */
			Assert.Null( test4list.GetNthLast(5) );
		}
		
	    [UnitTest]
	    public void TestList5_5thLast() 
		{
			/** ensure it won't cause a runtime error */
			Assert.Null( test5list.GetNthLast(5) );
		}

		/** fully test one of the arrays */
	    [UnitTest]
	    public void TestList1_NthLast() 
		{
			int l = test1list.Count();
			for (int i=0; i<l; i++)
			{

//				Assert.Equal( i, test1list.GetNthLast(l-i).data );
			 	/** todo: add type check (?) */
//				Assert.Equal("System.Int32", test1list.GetNthLast(l-i).data.GetType() ); 
			}
		}
		
		/*
		 * Test edge cases and out-of bounds 
		 */
	    [UnitTest]
	    public void TestList1EdgeCases() 
		{
			Assert.Equal( 1, test1list.GetNthLast(10).data );
			Assert.Equal( 9, test1list.GetNthLast(1).data );
			Assert.Null( test1list.GetNthLast(11) );
			Assert.Null( test1list.GetNthLast(0) );
			Assert.Null( test1list.GetNthLast(-1) );
		}
	    public void TestList2EdgeCases() 
		{
			Assert.Equal( 24, test2list.GetNthLast(6).data );
			Assert.Equal( -5, test2list.GetNthLast(1).data );
			Assert.Null( test2list.GetNthLast(7) );
			Assert.Null( test2list.GetNthLast(0) );
			Assert.Null( test2list.GetNthLast(-1) );
		}
	    public void TestList3EdgeCases() 
		{
			Assert.Equal( -1, test3list.GetNthLast(5).data );
			Assert.Equal( -5, test3list.GetNthLast(1).data );
			Assert.Null( test3list.GetNthLast(0) );
			Assert.Null( test3list.GetNthLast(-1) );
		}
	    public void TestList4EdgeCases() 
		{
			Assert.Null( test4list.GetNthLast(1) );
			Assert.Null( test4list.GetNthLast(0) );
			Assert.Null( test4list.GetNthLast(-1) );
		}
	    public void TestList5EdgeCases() 
		{
			Assert.Equal( 0, test5list.GetNthLast(3).data );
			Assert.Equal( 3, test5list.GetNthLast(1).data );
			Assert.Null( test5list.GetNthLast(4) );
			Assert.Null( test5list.GetNthLast(0) );
			Assert.Null( test5list.GetNthLast(-1) );
		}
		
		
			/* 
			 * test negative integers passed to the function don't cause runtime error
			 */
	    public void TestNegativeNth() 
		{
			Assert.Null( test2list.GetNthLast(-100) );

		}

	
	}
}


