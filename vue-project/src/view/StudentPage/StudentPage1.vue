<template>
    <!-- 欢迎！用户名 -->
    <h1>欢迎！{{ username }}</h1>
    
    
    <h2>请查看您的作业提交情况</h2>
    <!-- 用v-for渲染出来的无序列表，其中左边呈现的是作业号，右边呈现的是是否批改 -->
    <ol>
        <li v-for="item in Assignment">
            <div>
              作业号：{{ item.num }} &nbsp;&nbsp;&nbsp;&nbsp;
              批改状态:{{ item.state ? "已批改":"未批改" }}  &nbsp;&nbsp;&nbsp;&nbsp;
              <!-- 点击查看老师评语这个button之后跳转到批改界面，然后可以查看老师的批改情况（针对每一行代码） -->
              <button >查看批改情况</button>
            </div>
        </li>
    </ol>
    </template>
    
    <script>
      export default{
              data(){
                  return{
                      //TODO: 后端传进来username作为欢迎语
                      username: "张三",
                      //TODO: 后端传进来的作业号和批改状态,true表示已批改，false表示未批改，
                      //TODO: 还要实现一个功能是点击查看批改情况之后跳转到批改界面，然后可以查看老师的批改情况（针对每一行代码），这里我不太明白怎么实现，交给你了
                      Assignment:[
                        {num:"001", state:true},
                        {num:"002", state:false},
                      ]
                  }
              },
              methods:{
               
                  
              }
          } 
    </script>
    
    <style scoped>
    
    </style>
    