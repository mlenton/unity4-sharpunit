/*
 * ListTest.cs
 * Author: 		Matthew Lenton
 * Email: 		matthew.lenton@gmail.com
 * Date: 		September 2013
 * Description:	Implements tests on the GetNthLast method of SinglyLinkedList
 * 				Note that only the tests against the GetNth are implemented, 
 * 				not test against the basic list itself (eg. testing for loops etc.)
 */

using System;
using SharpUnit;
using SinglyLinkedListExample;

namespace Test_List_GetNthLast 
{ 
	public class List_GetNthLast : TestCase 
	{
		/** declarations for the test subjects */
		SinglyLinkedList<int> tenPositiveInt;
		SinglyLinkedList<int> fiveNegativeInt;
		SinglyLinkedList<int> zeroLengthList;		
		SinglyLinkedList<int> threeMixedInt;
			 
		/** Setup test resources, called before each test. */
	    public override void SetUp() 
		{
			
			/** a list of length zero */
			zeroLengthList = new SinglyLinkedList<int>(new int[] {});

			/** a list containing less than 5 integers */
			threeMixedInt = new SinglyLinkedList<int>(new int[] {1,-2,3});

			/** a list of length 5, also containing negative integers */
			fiveNegativeInt = new SinglyLinkedList<int>(new int[] {-1,-2,-3,-4,-5});

			/** a list of positive integers */
			tenPositiveInt = new SinglyLinkedList<int>(new int[] {0,1,2,3,4,5,6,7,8,9});

			/* todo: ensure using new int[] in cstr parameter in this way does not cause memory leak 
			 * done as such for brevity & readability, for the purposes of this exercise 
			 */
		}
	
	    /** Dispose of test resources, called after each test */
	    public override void TearDown() 
		{
			zeroLengthList = null;
			threeMixedInt = null;
			fiveNegativeInt = null;
			tenPositiveInt = null;
	    }
		
		/*
		 * Test the 'fifth-last' cases for each of the test lists 
		 * Note: testing the length lists to ensure they haven't changed somehow
		 */

	    [UnitTest]
	    public void TestZeroLengthList_5thLast() 
		{
			/** ensure it won't cause a runtime error */
			Assert.Equal( 0, zeroLengthList.Count() );
			Assert.Null( zeroLengthList.GetNthLast(5) );
		}
		
	    [UnitTest]
	    public void TestThreeMixedInt_5thLast() 
		{
			/** ensure it won't cause a runtime error */
			Assert.Equal( 3, threeMixedInt.Count() );
			Assert.Null( threeMixedInt.GetNthLast(5) );
		}
				
	    [UnitTest]
	    public void TestFiveNegativeInt_5thLast() 
		{
			/** ensure the correct value is returned */
			Assert.Equal( 5, fiveNegativeInt.Count() );
			Assert.Equal( -1, fiveNegativeInt.GetNthLast(5).data );
		}

	    [UnitTest]
	    public void TestTenPositiveInt_5thLast() 
		{
			/** ensure the correct value is returned */
			Assert.Equal( 10, tenPositiveInt.Count() );
			Assert.Equal( 5, tenPositiveInt.GetNthLast(5).data );
		}

		/*
		 * fully test the list with ten, deliberately set up so the test is easily written 
		 */

	    [UnitTest]
	    public void TestTenPositiveInt_NthLast() 
		{
			int l = tenPositiveInt.Count();
			for (int i=0; i<l; i++)
			{
				Assert.Equal( i, tenPositiveInt.GetNthLast(l-i).data );
			}
		}

		/*
		 * Test edge cases and out-of-bounds 
		 * Grouped multiple tests on same list for brevity and readability
		 */

	    [UnitTest]
	    public void TestZeroLengthList_EdgeCases() 
		{
			Assert.Equal( 0, zeroLengthList.Count() );
			Assert.Null( zeroLengthList.GetNthLast(1) );
			Assert.Null( zeroLengthList.GetNthLast(0) );
			Assert.Null( zeroLengthList.GetNthLast(-1) );
		}

	    [UnitTest]
	    public void TestThreeMixedInt_EdgeCases() 
		{
			Assert.Equal( 3, threeMixedInt.Count() );
			Assert.Equal( 1, threeMixedInt.GetNthLast(3).data );
			Assert.Equal( 3, threeMixedInt.GetNthLast(1).data );
			Assert.Null( threeMixedInt.GetNthLast(4) );
			Assert.Null( threeMixedInt.GetNthLast(0) );
			Assert.Null( threeMixedInt.GetNthLast(-1) );
		}

	    [UnitTest]
	    public void TestFiveNegativeInt_EdgeCases() 
		{
			Assert.Equal( 5, fiveNegativeInt.Count() );
			Assert.Equal( -1, fiveNegativeInt.GetNthLast(5).data );
			Assert.Equal( -5, fiveNegativeInt.GetNthLast(1).data );
			Assert.Null( fiveNegativeInt.GetNthLast(6) );
			Assert.Null( fiveNegativeInt.GetNthLast(0) );
			Assert.Null( fiveNegativeInt.GetNthLast(-1) );
		}

	    [UnitTest]
	    public void TestTenPositiveInt_EdgeCases() 
		{
			Assert.Equal( 10, tenPositiveInt.Count() );
			Assert.Equal( 0, tenPositiveInt.GetNthLast(10).data );
			Assert.Equal( 9, tenPositiveInt.GetNthLast(1).data );
			Assert.Null( tenPositiveInt.GetNthLast(11) );
			Assert.Null( tenPositiveInt.GetNthLast(0) );
			Assert.Null( tenPositiveInt.GetNthLast(-1) );
		}
	}
}


