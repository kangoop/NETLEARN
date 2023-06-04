using Microsoft.AspNetCore.Mvc;
using restapi_learn.Models;
using restapi_learn.Service;

namespace restapi_learn.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class PizzaController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();


        [HttpGet("/[controller]/{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if(pizza == null)
            {
                return NotFound();
            }

            return pizza;
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);

            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
            /*
             * CreatedAtAction 메서드 호출의 첫 번째 매개 변수는 동작 이름을 나타냅니다. 
             CreatedAtAction은 작업 이름을 사용하여 이전 단원에서 설명한 대로 새로 생성된 피자 URL이 포함된 location HTTP 응답 헤더를 생성
             */
        }
        /*
CreatedAtAction	201	피자가 메모리 내 캐시에 추가되었습니다.
accept HTTP 요청 헤더(기본적으로 JSON)에 정의된 대로 미디어 유형의 응답 본문에 피자가 포함됩니다.
BadRequest가 암시됩니다.	400	요청 본문의 pizza 개체가 잘못되었습니다.
         */

        [HttpPut("/[controller]/{id}")]
        public IActionResult Update(int id,Pizza pizza)
        {
            if(id != pizza.Id)
            {
                return BadRequest();
            }

            var existingPizza = PizzaService.Get(id);
            if(existingPizza is null)
            {
                return NotFound();
            }

            PizzaService.Update(pizza);

            return NoContent();
        }
        /*
 NoContent	204	피자가 메모리 내 캐시에서 업데이트되었습니다.
BadRequest	400	요청 본문의 Id 값이 경로의 id 값과 일치하지 않습니다.
BadRequest가 암시됩니다.	400	요청 본문의 Pizza 개체가 잘못되었습니다.
         */

        [HttpDelete("/[controller]/{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);

            if(pizza is null)
            {
                return NotFound();
            }

            PizzaService.Delete(id);

            return NoContent();
        }
        /*
NoContent	204	피자가 메모리 내 캐시에서 삭제되었습니다.
NotFound	404	제공된 id 매개 변수와 일치하는 피자는 메모리 내 캐시에 존재하지 않습니다.
         */
    }

}
