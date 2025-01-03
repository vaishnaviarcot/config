using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Accounts.Controllers
{
    [ApiController]
    [Route("api/stack")]
    public class AccountsController : ControllerBase
    {
        private static Stack<string> _stack = new Stack<string>();
        [HttpGet]
        public IActionResult Peek()
        {
            if (_stack.Count == 0)
                return NewMethod();
            return Ok(new { Top = _stack.Peek(), Count = _stack.Count });
        }
        private IActionResult NewMethod()
        {
            return NotFound(new { Message = "Stack is empty." });
        }
        [HttpPost]
        public IActionResult Push([FromBody] string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return BadRequest(new { Message = "Value cannot be null or empty." });
            }
            _stack.Push(value);
            return Ok(new { Message = "Item pushed successfully.", Stack = _stack });
        }
        [HttpDelete]
        public IActionResult Pop()
        {
            if (_stack.Count == 0)
            {
                return NotFound(new { Message = "Stack is empty. Cannot pop an item." });
            }
            string poppedItem = _stack.Pop();
            return Ok(new { Message = "Item popped successfully.", PoppedItem = poppedItem, RemainingStack = _stack });
        }
    }
}


