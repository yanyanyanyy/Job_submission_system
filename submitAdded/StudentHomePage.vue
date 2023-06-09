<template>
  <h1>欢迎！{{username}}</h1>
    <!--本页面是登陆后的学生的第一个页面，在这个页面里可以跳转至查看新发布的作业和查看老师评语两个页面-->
  <div>
    <el-button type="primary">查看批改情况</el-button>
  </div>
  <br><br><br>
  <div>
    <el-button type="success">查看新发布的作业</el-button>
  </div>
  </template>
      
      <script>
        export default{
                data(){
                    return{
                      //TODO: 后端传进来username作为欢迎语
                        username: "张三",
                    }
                },
                methods:{
                 
                    
                }
            } 
      </script>
      
      <style scoped>
      
      </style>
      