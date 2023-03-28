using System;
namespace OppgaveSimuleringFinneLoesningPaaFlaskeoppgaver
{
    public class Calculator
    {
        private Bottle _bottle1;
        private Bottle _bottle2;
        private int _wantedVolume;
        private int _numberOfOperations;
        private int[] _operations;

        public Calculator(int bottleOneCapacity, int bottleTwoCapacity, int wantedVolume)
        {
            _bottle1 = new Bottle(bottleOneCapacity);
            _bottle2 = new Bottle(bottleTwoCapacity);
            _wantedVolume = wantedVolume;
            _numberOfOperations = 1;
        }
        public void Calculate()
        {

            while (true)
            {
                var searchOver = TryWithGivenNumberOfOperations();
                if (searchOver) break;
                _numberOfOperations++;
            }
        }
        private bool TryWithGivenNumberOfOperations()
        {
            Console.WriteLine("Prøver med " + _numberOfOperations + " operasjon(er).");
            _operations = new int[_numberOfOperations];
            while (true)
            {
                DoOperations();
                if (CheckIfSolved()) return true;
                var success = UpdateOperations();
                if (!success) return false;
            }
        }
        private void DoOperations()
        {
            _bottle1.Empty();
            _bottle2.Empty();

            foreach (var operation in _operations)
            {
                if (operation == 0) _bottle1.FillToTopFromTap(); // Fill bottle 1 from the tap 
                else if (operation == 1) _bottle2.FillToTopFromTap(); // Fill bottle 2 from the tap 
                else if (operation == 2) _bottle2.Fill(_bottle1.Empty()); // Empty bottle 1 into bottle 2 - 
                                                                        // The idea is that Empty() returns how much was in the bottle before it was emptied 
                else if (operation == 3) _bottle1.Fill(_bottle2.Empty()); // Empty bottle 2 into bottle 1 
                else if (operation == 4) _bottle2.FillToTop(_bottle1); // Fill bottle 2 with bottle 1
                                                                     // The idea is that FillToTop takes another Bottle as a parameter. If it's enough, it 
                                                                     // fills bottle2 and reduces bottle1 accordingly. If not, it does nothing. 
                else if (operation == 5) _bottle1.FillToTop(_bottle2); // Fill up bottle 1 with bottle 2 
                else if (operation == 6) _bottle1.Empty(); // Empty bottle 1 (discard the water) 
                else if (operation == 7) _bottle2.Empty(); // Empty bottle 2 (discard the water)
            }
        }
        private bool CheckIfSolved()
        {
            if (_bottle1.Content == _wantedVolume || _bottle2.Content == _wantedVolume || _bottle1.Content + _bottle2.Content == _wantedVolume)
            {
                ShowOperations();
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool UpdateOperations()
        {
            int i;
            for (i = _operations.Length - 1; i >= 0; i--)
            {
                if (_operations[i] < 7)
                {
                    _operations[i]++;
                    break;
                }
                _operations[i] = 0;
            }
            return i != -1;
        }
        private void ShowOperations()
        {
            Console.WriteLine();
            Console.WriteLine($"Found the desired volume with this sequence of operations: ");

            var operationNames = new string[] { "Fylle flaske 1 fra springen",
                                                "Fylle flaske 2 fra springen",
                                                "Tømme flaske 1 i flaske 2",
                                                "Tømme flaske 2 i flaske 1",
                                                "Fylle opp flaske 2 med flaske 1",
                                                "Fylle opp flaske 1 med flaske 2",
                                                "Tømme flaske 1 (kaste vannet)",
                                                "Tømme flaske 2 (kaste vannet)", };
            for (int i = 0; i < _operations.Length; i++)
            {
                Console.WriteLine(operationNames[_operations[i]]);
            }
            Console.WriteLine();
        }
    }
}

