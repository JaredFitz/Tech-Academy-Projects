function orderSize() {
    var text1 = "";
    var runningTotal=0;
    var sizeTotal=0;
    var sizeArray=document.getElementsByClassName("pizzaSizes")

    for (var i=0; i < sizeArray.length; i++) {
        if (sizeArray[i].checked) {
            var selectedSize=sizeArray[i].value;
        }
    }

    if (selectedSize==="Personal Pizza") {
        sizeTotal=6;
    } else if (selectedSize==="Medium Pizza") {
        sizeTotal=10;
    } else if (selectedSize==="Large Pizza") {
        sizeTotal=14;
    } else if (selectedSize==="XL Pizza") {
        sizeTotal=16;
    }

    text1=text1 + selectedSize + " ($" + sizeTotal + ".00)<br>";

    runningTotal=sizeTotal;
    console.log(selectedSize+" = $" + sizeTotal + ".00");
    console.log("size text1: "+text1);
    console.log("subtotal: $"+runningTotal+".00");
    orderMeat(runningTotal, text1);
};

function orderMeat (runningTotal, text1) {
    var meatCost=0;
    var selectedMeat=[];
    var meatArray=document.getElementsByClassName("pizzaMeats");

    for (var i=0; i < meatArray.length; i++) { //Going through all the meats to find if they are checked.  If so, they are added to the selectedMeat array.
        if (meatArray[i].checked) {
            selectedMeat.push(meatArray[i].value);
            console.log("selected meat item: (" + meatArray[i].value + ")");
            meatCost = selectedMeat.length;
            if (meatCost <= 1) {
                text1 = text1 + meatArray[i].value + "<br>";
            } else {
                text1 = text1 + meatArray[i].value + " (+$1.00)<br>"; //Each additional meat after the first costs extra
            }
                
        }
    }

    if (meatCost <= 1) {
        meatCost = 0
    } else {
        meatCost = meatCost-1
    }
    
    runningTotal = runningTotal + meatCost;
    orderCheese(runningTotal, text1);
};

function orderCheese(runningTotal, text1) {
    var cheeseArray=document.getElementsByClassName("pizzaCheeses");
    var cheeseCost=0;

    for (var i=0; i < cheeseArray.length; i++) {
        if (cheeseArray[i].checked) {
            var selectedCheese=cheeseArray[i].value;
            console.log("selected cheese: (" + selectedCheese + ")");
            text1=text1+selectedCheese + "<br>";
        }
    }

    if (selectedCheese === "Extra Cheese (+$3.00)") {
        cheeseCost = 3;
    }

    runningTotal = runningTotal + cheeseCost;
    orderCrust(runningTotal, text1);
};

function orderCrust(runningTotal, text1) {
    var crustArray=document.getElementsByClassName("pizzaCrusts");
    var crustCost=0;

    for (i=0; i < crustArray.length; i++) {
        if (crustArray[i].checked) {
            var selectedCrust=crustArray[i].value;
            console.log("selected crust: (" + selectedCrust + ")");
            text1=text1+selectedCrust+"<br>";
        }
    }

    if (selectedCrust === "Cheese Stuffed Crust (+$3.00)") {
        crustCost=3;
    }

    runningTotal = runningTotal + crustCost;
    orderSauce(runningTotal, text1);
};

function orderSauce(runningTotal, text1) {
    var sauceArray = document.getElementsByClassName("pizzaSauces");
    
    for (i=0; i< sauceArray.length; i++) {
        if (sauceArray[i].checked) {
            var selectedSauce=sauceArray[i].value;
            console.log("selected sauce: (" + selectedSauce + ")");
            text1=text1+selectedSauce+"<br>";
        }
    }

    orderVeggies(runningTotal, text1);
};

function orderVeggies(runningTotal,text1) {
    var veggieCost=0;
    var veggieArray=document.getElementsByClassName("pizzaVeggies");
    var selectedVeggies=[];

    for (i=0; i<veggieArray.length; i++) {
        if (veggieArray[i].checked) {
            selectedVeggies.push(veggieArray[i].value);
            console.log("selected veggie item: (" + veggieArray[i].value + ")");
            veggieCost=selectedVeggies.length;
            if (veggieCost <= 1) {
                text1 = text1 + veggieArray[i].value + "<br>";
            } else {
                text1 = text1 + veggieArray[i].value + " (+$1.00)<br>";//Each additional meat after the first costs extra
            }
        }
    }

    if (veggieCost <=1) {
        veggieCost = 0;
    } else {
        veggieCost = veggieCost - 1;
    }

    runningTotal = runningTotal + veggieCost;
    orderSummary(runningTotal, text1);
};

function orderSummary (runningTotal, text1) {
    text1 = text1 + "____________________________________<br>Total Cost: $" + runningTotal + ".00";
    console.log(text1);
    document.getElementById("finalSummary").innerHTML = "<div class=\"card mx-auto\" style=\"width: 20rem;\"><div class=\"card-body\"><h3 class=\"card-title\">You Ordered:</h3><p class=\"card-text\" style=\"text-align:left;\">" + text1 + "</p></div></div>";
}