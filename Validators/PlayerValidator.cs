using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInOne
{
    public class PlayerValidator : AbstractValidator<PlayerModel>
    {
        public PlayerValidator()
        {

            RuleFor(player => player.PlayerName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(2, 10).WithMessage("Namnet måste vara mellan 2 till 10 bokstäver långt!")
                .Matches("^[a-zA-ZåäöÅÄÖ]+$").WithMessage("Namnet kan bara bestå av bokstäver!");
        }
    }
}
