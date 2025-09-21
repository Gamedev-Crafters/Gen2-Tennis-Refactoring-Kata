namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int _player1Score = 0;
        private int _player2Score = 0;

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _player1Score += 1;
            else
                _player2Score += 1;
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            
            if (_player1Score == _player2Score)
            {
                score = GetTitleDrawScore(_player1Score);
            }
            else if (_player1Score >= 4 || _player2Score >= 4)
            {
                score = ManageDeuceGame(_player1Score, _player2Score);
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = _player1Score;
                    else { score += "-"; tempScore = _player2Score; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }

        private string ManageDeuceGame(int player1Score, int player2Score)
        {
            var player1Advantage = player1Score - player2Score;
            return player1Advantage switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2"
            };
        }

        private string GetTitleDrawScore(int drawScore)
        {
            return drawScore switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
        }
    }
}

