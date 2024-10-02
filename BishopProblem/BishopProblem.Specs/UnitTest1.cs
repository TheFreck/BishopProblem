using Machine.Specifications;

namespace BishopProblem.Specs
{
    public class When_Finding_Number_Of_Moves_And_Square_Is_Reachable
    {
        Establish context = () =>
        {
            inputs = new List<(int from, int to, int moves)>
            {
                (23,1,2),
                (0,4,2),
                (40,39,2),
                (44,23,1),
                (59,32,1)
            };
            outcomes = new List<int>();
        };

        Because of = () => 
        {
            for(var i=0; i<inputs.Count; i++)
            {
                outcomes.Add(BishopService.GetMoves(inputs[i].from, inputs[i].to));
            }
        };

        It Should_Return_Correct_Number_Of_Moves = () =>
        {
            for (var i = 0; i < outcomes.Count; i++)
            {
                outcomes[i].ShouldEqual(inputs[i].moves);
            }
        };

        private static List<(int from, int to, int moves)> inputs;
        private static List<int> outcomes;
    }

    public class When_Finding_Number_Of_Moves_And_Square_Is_Not_Reachable
    {
        Establish context = () =>
        {
            inputs = new List<(int from, int to, int moves)>
            {
                (23,2,-1),
                (0,55,-1),
                (40,41,-1)
            };
            outcomes = new List<int>();
        };

        Because of = () =>
        {
            for (var i = 0; i < inputs.Count; i++)
            {
                outcomes.Add(BishopService.GetMoves(inputs[i].from, inputs[i].to));
            }
        };

        It Should_Return_Correct_Number_Of_Moves = () =>
        {
            for (var i = 0; i < outcomes.Count; i++)
            {
                outcomes[i].ShouldEqual(inputs[i].moves);
            }
        };

        private static List<(int from, int to, int moves)> inputs;
        private static List<int> outcomes;
    }

    public class When_Finding_Squares_One_Move_Away
    {
        Establish context = () =>
        {
            inputs = new List<(int from, List<int> squares)>
            {
                (0,new List<int>{9,18,27,36,45,54,63}),
                (1,new List<int>{8,10,19,28,37,46,55}),
                (2,new List<int>{9,16,11,20,29,38,47}),
                (3,new List<int>{10,17,24,12,21,30,39}),
                (35, new List<int>{8,17,26,44,53,62,42,49,56,28,21,14,7}),
                (27, new List<int>{0,9,18,34,41,48,20,13,6,36,45,54,63}),
                (54,new List<int>{0,9,18,27,36,45,63,61,47})
            };
            outcomes = new List<List<int>> ();
        };

        Because of = () =>
        {
            for (var i = 0; i < inputs.Count; i++)
            {
                outcomes.Add(BishopService.GetSquares(inputs[i].from));
            }
        };

        It Should_Return_All_Squares_Reachable_In_One_Turn = () =>
        {
            for (var i = 0; i < outcomes.Count; i++)
            {
                outcomes[i].ShouldContainOnly(inputs[i].squares);
            }
        };

        private static List<(int from, List<int> squares)> inputs;
        private static List<List<int>> outcomes;
    }
}