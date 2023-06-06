<template>
    <!--本页面为学生点击查看新发布的作业后的页面-->
  
    <div class="top">
      <span>
        <span class="top-left">  
          <!--此处为新加的选择按钮，在这里可以添加班级，功能没做-->
          <el-button type="primary">添加班级</el-button>
          <!--点击代码库地址之后可以修改代码库，应该是弹出一个弹窗可以输入代码库地址,但是写的有点问题，不知道为什么无法弹窗-->
          <el-button type="success" onclick="alertInput()">修改库地址</el-button>
  
            <el-text class="mx-1" type="warning" size="large">请选择班级  </el-text>
                <el-select v-model="classNum" placeholder="请选择你的班级">
                  <el-option label="计科6班" value="cs-class6" />
                  <el-option label="计科3班" value="cs-class3" />
                </el-select>
          </span>
      </span>
    </div>
    
     <div class="studentUnsubmmitTask">
       <container>
         <container-header><h1>请查看您的作业</h1></container-header>
         <container-main>
           <div class="demo-collapse">
             <el-collapse v-model="activeNames" @change="handleChange">
  
               <el-collapse-item title="作业001" name="1">
                 <div>作业要求：</div>
                 <div>{{ assignmentNum[0].assignmentRequest }}</div>
               </el-collapse-item>
  
               <el-collapse-item title="作业002" name="2">
                 <div>作业要求：</div>
                 <div>{{ assignmentNum[1].assignmentRequest }}</div>
               </el-collapse-item>
  
               <el-collapse-item title="作业003" name="3">
                 <div>作业要求：</div>
                 <div>{{ assignmentNum[2].assignmentRequest }}</div>
               </el-collapse-item>
  
               <el-collapse-item title="作业004" name="4">
                 <div>作业要求：</div>
                 <div>{{ assignmentNum[3].assignmentRequest }}</div>
               </el-collapse-item>
       
             </el-collapse>
           </div>
         </container-main>
   
         <container-footer>
           <!--返回按钮-->
           <el-button type="info">返回上一页</el-button>
         </container-footer>
       </container>
     </div>
  </template>
   
   <script>
     export default{
       data(){
         return{
           assignmentNum:[
             {
               assignmentNum: "001",
               assignmentRequest: "作业要求1"
             },
             {
               assignmentNum: "002",
               assignmentRequest: "作业要求2"
             },
             {
               assignmentNum: "003",
               assignmentRequest: "作业要求3"
             },
             {
               assignmentNum: "004",
               assignmentRequest: "作业要求4"
             }
           ],
         }
       },
  
       methods:{
        alertInput: function(){
          var input = prompt("请输入代码库地址");
        }
  
       }
     }
     
   </script>
   
   <style lang="scss" scoped>
     .studentUnsubmmitTask{
       width: 100%;
       height: 100%;
       .el-button{
         float:right;
       }
     }
       
  
  
   </style>