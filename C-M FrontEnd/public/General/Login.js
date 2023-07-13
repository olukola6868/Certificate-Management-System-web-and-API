const url = "http://localhost:5070/api/User/Login";
const myform = document.querySelector('#sign-in-form');
myform.addEventListener('submit', (x) => {
  x.preventDefault();
  console.log(myform);

  let sendForm = new FormData(myform);
  console.log(sendForm)
  fetch(url,
    {
      method: "POST",
      body: sendForm,
    })
    .then((response) => response.json())
    .then(function (value) {
      console.log(value);
      if (value.status == true) {
        localStorage.setItem('loginid', value.data.id);
        window.alert("Login successful")
        value.data.roles.forEach(x => {
          console.log(x)
          if (x.name == "Organization") {
            location.href = "/public/index.html"
          }
          else if (x.name == "Admin") {
            location.href = "/public/Admin.html"
          }
          else {
            console.log("Role does not exist")
          }
        });
      }
      else {
        window.alert(value.message);
      }
    })
    .catch((res) => {
      console.log("Hello")
      window.alert(res)
    })

});