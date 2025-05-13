
// Function to show Sweet Alert success
function showSuccessAlert() {
  Swal.fire({
    title: 'Success!',
    text: 'Your action has been successfully executed.',
    icon: 'success',
    confirmButtonColor: '#3085d6',
    confirmButtonText: 'OK'
  });
}

// Attach the click event to elements with the 'sa-success' class for success alert
document.querySelectorAll('.sa-success').forEach(function (element) {
  element.addEventListener('click', showSuccessAlert);
});




// Function to show Sweet Alert warning
function showWarningAlert() {
  Swal.fire({
    title: '<b>Are you sure?</b>',
    text: 'You are about to perform a dangerous action!',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    confirmButtonText: 'Yes, proceed!'
  }).then((result) => {
    if (result.isConfirmed) {
      // Handle the confirmation, e.g., perform the delete action
      showSuccessAlert(); // Display success alert
    }
  });
}




// Attach the click event to elements with the 'sa-warning' class
document.querySelectorAll('.sa-warning').forEach(function (element) {
  element.addEventListener('click', showWarningAlert);
});


// Function to show HoldingQuantityAlert
function HoldingQuantityAlert() {
  Swal.fire({
    title: '<b>Max Holding Exceeded</b>',
    text: 'Do you want to continue ?',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    confirmButtonText: 'Yes, proceed!'
  }).then((result) => {
    if (result.isConfirmed) {
      // Handle the confirmation, e.g., perform the delete action
      showSuccessAlert(); // Display success alert
    }
  });
}

// Attach the click event to elements with the 'sa-QuantityAlert' class
document.querySelectorAll('.sa-QuantityAlert').forEach(function (element) {
  element.addEventListener('click', HoldingQuantityAlert);
});


// // Function to show Sweet Alert failure
// function showFailureAlert() {
//   Swal.fire({
//     title: 'Failure!',
//     text: 'Your action has failed.',
//     icon: 'error',
//     confirmButtonColor: '#d33',
//     confirmButtonText: 'OK'
//   });
// }

// // Attach the click event to elements with the 'sa-failure' class for failure alert
// document.querySelectorAll('.sa-failure').forEach(function (element) {
//   element.addEventListener('click', showFailureAlert);
// });


// Function to show Sweet Alert failure
function showFailureAlert() {
  Swal.fire({
    title: 'Failure!',
    text: 'Your action has failed.',
    icon: 'error',
    confirmButtonColor: '#d33',
    confirmButtonText: 'OK'
  });
}


// Function to show Sweet Alert
function showDuplicateAlert() {
  Swal.fire({
    title: 'Duplicate Record Found!',
    text: 'This record already exists. Do you still want to add it?',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonColor: '#6dcba3',
    cancelButtonColor: '#e1665d',
    confirmButtonText: ' <span onclick="showFailureAlert()">Yes, Add it!</span> ',
    cancelButtonText: 'Cancel'
  }).then((result) => {
    if (result.isConfirmed) {
      // Code to proceed with adding the record
      Swal.fire(
        'Added!',
        'The record has been added.',
        'success'

      );
    } 
  });
}

//Add User  Add address user master form


function show(divId) {
  $("#" + divId).show();
}

function hide(divId) {
  $("#" + divId).hide();
}


function Show_Address_1() {
  show('Address_1');
  event.preventDefault();
}
function Show_Address_2() {
  show('Address_2');
  event.preventDefault();
}

function Close_Address_1() {
  hide('Address_1');
  event.preventDefault();
}
function Close_Address_2() {
  hide('Address_2');
  event.preventDefault();
}


//function to Hide and show Purchase Order

function Show_Po_1(){
  show('Po_1')
}




Dropzone.autoDiscover = false;

// Dropzone configuration
var myDropzone = new Dropzone(".dropzone", {
  url: "/file/post",
  paramName: "file",
  maxFilesize: 2, // MB
  maxFiles: 10,
  acceptedFiles: 'image/*',
  dictDefaultMessage: "Drag files here or click to upload.",
  clickable: true
});


function Select_Gas_Type() {
  var selectElement = document.querySelector('.Select_option');
  var Cylinder_FamilyDiv = document.querySelector('.Cylinder_Family');
  var Gas_CategoryDiv = document.querySelector('.Gas_Category');


  if (selectElement.value === "Cylinder_Family") {
    Cylinder_FamilyDiv.style.display = "block";
  } else {
    Cylinder_FamilyDiv.style.display = "none";
  }

  if (selectElement.value === "Gas_Category") {
    Gas_CategoryDiv.style.display = "block";
  } else {
    Gas_CategoryDiv.style.display = "none";
  }
}


//Function to Show Cyl Type in User Invoice
function Select_Gas_Type_Tax() {
  var selectElement_Tax = document.querySelector('.Select_option_Tax');
  var Cylinder_Family_TaxDiv = document.querySelector('.Cylinder_Family_Tax');
  var Gas_Category_TaxDiv = document.querySelector('.Gas_Category_Tax');


  if (selectElement_Tax.value === "Cylinder_Family_Tax") {
    Cylinder_Family_TaxDiv.style.display = "block";
  } else {
    Cylinder_Family_TaxDiv.style.display = "none";
  }

  if (selectElement_Tax.value === "Gas_Category_Tax") {
    Gas_Category_TaxDiv.style.display = "block";
  } else {
    Gas_Category_TaxDiv.style.display = "none";
  }
}

// Function to Show Charge Type Per Cylinder 
function Select_Charge_type() {
  var selectElement_Charge_type = document.querySelector('.Select_Charge');
  var Per_Cylinder_Div = document.querySelector('.per_cylinder');


  if (selectElement_Charge_type.value === "per_cylinder") {
    Per_Cylinder_Div.style.display = "block";
    
  } else {
    Per_Cylinder_Div.style.display = "none";
  }

}

// functon to Show Cylinder Varient on Party Invoice Page
function Selecttype() {
  var selectElement_Charge_type = document.querySelector('.SelectTypegas');
  var Gas_Varient_Divs = document.querySelectorAll('.Select_Gas_Varient');
  var Cylinder_Family_Divs = document.querySelectorAll('.Select_Cylinder_Family')

  if (selectElement_Charge_type.value === "Select_Gas_Varient") {
    Gas_Varient_Divs.forEach(function(div) {
      div.style.display = "block";
    });
  } else {
    Gas_Varient_Divs.forEach(function(div) {
      div.style.display = "none";
    });
  }

  if(selectElement_Charge_type.value === "Select_Cylinder_Family"){
    Cylinder_Family_Divs.forEach(function(div) {
      div.style.display = "block";
    });
  }else{
    Cylinder_Family_Divs.forEach(function(div){
      div.style.display = "none";
    });
  }
}


  

function Select_Owner_Type() {
  var ownerTypeDropdown = document.querySelector(".form-floating.Select_option select");
  var ownershipDropdown = document.querySelector(".Owner_selected");

  if (ownerTypeDropdown.value === "Own") {
      ownershipDropdown.style.display = "none";
  } else {
      ownershipDropdown.style.display = "block";
  }
}


//Rent Slab Add New Row
function show(divId) {
  $("#" + divId).show();
}

function hide(divId) {
  $("#" + divId).hide();
}


function Show_Field_1() {
  show('Field_1');
}
function Show_Field_2() {
  show('Field_2');
}
function Show_Field_3() {
  show('Field_3');
}
function Show_Field_4() {
  show('Field_4');
}


//Generate Invoice fields to add Invoices
function show_Invo(divId) {
  $("#" + divId).show();
}

function hide_Invo(divId) {
  $("#" + divId).hide();
}


function Show_Invoice_Field_1() {
  show_Invo('Invoice_Field_1');
}
function Show_Invoice_Field_2() {
  show_Invo('Invoice_Field_2');
}
function Show_Invoice_Field_3() {
  show_Invo('Invoice_Field_3');
}
function Show_Invoice_Field_4() {
  show_Invo('Invoice_Field_4');
}

// Maintanance

function Show_Invoice_Field_11() {
  show_Invo('Invoice_Field_11');
}
function Show_Invoice_Field_12() {
  show_Invo('Invoice_Field_12');
}
function Show_Invoice_Field_13() {
  show_Invo('Invoice_Field_13');
}
function Show_Invoice_Field_14() {
  show_Invo('Invoice_Field_14');
}

// Maintanance

function Show_Invoice_Field_21() {
  show_Invo('Invoice_Field_21');
}
function Show_Invoice_Field_22() {
  show_Invo('Invoice_Field_22');
}
function Show_Invoice_Field_23() {
  show_Invo('Invoice_Field_23');
}
function Show_Invoice_Field_24() {
  show_Invo('Invoice_Field_24');
}




