const examTime = 1;    //考试时间
const topicScore = 5;   //每题的得分
function keyDown() {
    if (event.keyCode == 8) {   //退格
        event.keyCode = 0;
        event.returnValue = false;
    }
    if (event.keyCode == 13) {  //回车
        event.keyCode = 0;
        event.returnValue = false;
    }
    if (event.keyCode == 116) { //F5
        event.keyCode = 0;
        event.returnValue = false;
    }
}

function showTime() {
    var now = new Date();
    years = now.getFullYear();
    maths = now.getMonth() + 1; //return 0-11
    dates = now.getDate();
    hours = now.getHours();
    minutes = now.getMinutes();
    seconds = now.getSeconds();
    hours = (hours < 10) ? "0" + hours : hours;
    minutes = (minutes < 10) ? "0" + minutes : minutes;
    seconds = (seconds < 10) ? "0" + seconds : seconds;
    var titleText = "当前日期时间为:" + years + "年" + "月" + dates + "日" + hours + ":" + minutes + ":" + seconds;
    setTimeout(showTime, 1000); //执行完当前函数后 等待1000ms再执行showtime（）
    document.title = titleText;
}

function countDown() {
    var second = 0;
    var minute = 0;
    idt = setTimeout(ls, 1000);
    function ls() {
        second++;
        if (second == 60) {
            second = 0;
            minute += 1;
        }
        if (minute == 60) {
            minute = 0;
        }
        document.getElementById("TimeLabel").innerHTML = minute + "分" + second + "秒";
        idt = setTimeout(ls, 1000);
        if (minute == examTime) {
            document.getElementById("SubmitBtn").click();
        }
    }
}

function examText() {
    document.getElementById("ExamLabel").innerHTML = "考试时间为" + examTime + "分钟，每小题" + topicScore + "分，考试已用时：";
}

function init() {
    showTime();
    examText();
    countDown();
}
