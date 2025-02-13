
let display = document.querySelector("#display");
let result = "";

let buttons = document.querySelectorAll("button");
display.value = "";

buttons.forEach(btn => btn.addEventListener("click", (evt)=>{
    console.log(result);
    if (btn.innerHTML === "="){
        result = eval(result).toString();
        display.value = parseFloat(result);
    }
    else if (btn.innerHTML === "CE"){
        result = result.slice(0, -1);
        display.value = result;
    }
    else if (btn.innerHTML === "C"){
        result = "";
        display.value = result;
    }
    else if ((result.charAt(result.length-1) === "+" || result.charAt(result.length-1) === "-" || result.charAt(result.length-1) === "*" || result.charAt(result.length-1) === "/") &&
        (btn.innerHTML === "+" || btn.innerHTML === "-" || btn.innerHTML === "*" || btn.innerHTML === "/")){
        result = result.slice(0, -1);
        result += btn.innerHTML;
        display.value = result;
    }
    else{
        result += btn.innerHTML;
        display.value = result;
    }
    
}))

