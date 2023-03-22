let signIn = document.getElementById("signIn");
let dataUser = JSON.parse(localStorage.getItem("data"));
signIn.onclick = function () {
  let email = document.getElementById("emailSignIn").value;
  let password = document.getElementById("passwordSignIn").value;
  let indexCheckEmail = -1;

  //   Kiểm tra tính hợp lệ của password
  console.log("password.length: ", password.length);
  if (password.length < 5 || password.length >= 20) {
    alert("Password không hợp lệ");
    flagSuccess = false;
  }
  //   Kiểm tra tính hợp lệ của email
  if (!email.includes("@") && !email.includes(".com")) {
    alert("Email không hợp lệ");
    flagSuccess = false;
  }
  for (let i = 0; i < dataUser.length; i++) {
    if (dataUser[i].email === email) {
      indexCheckEmail = i;
    }
  }
  if (indexCheckEmail !== -1) {
    if (dataUser[indexCheckEmail].password === password) {
      let loginSuccess = true;
      localStorage.setItem("loginSuccess", JSON.stringify(loginSuccess));
      alert("Đăng nhập thành công");
      //   Code này để điều hướng sang trang khác
      window.location.href = "http://www.google.com";
    } else {
      alert("Sai password");
    }
  } else {
    alert("Email chưa đăng ký");
  }
};
