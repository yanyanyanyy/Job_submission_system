<template>
  <!--本页面为学生点击查看新发布的作业后的页面-->

  <!--这里可以用css美化一下，我写得很简陋-->
  您的代码库地址为：  {{ inputAddress }}
  <div class="top">
    <span>
      <span class="top-left">  
        <!--此处为新加的选择按钮，在这里可以添加班级，添加的班级会传到classNum中-->
        <el-button type="primary" @click="addClass()">添加班级</el-button>
        <!--点击代码库地址之后可以修改代码库-->
        <el-button type="success" @click="alertInput()">修改库地址</el-button>

          <el-text class="mx-1" type="warning" size="large">请选择班级</el-text>
              <!--请选择你的班级-->
              <el-select v-model="classNumSelected" class="m-2" placeholder="请选择你的的班级">
              <el-option
                v-for="item in classNum"
                :label="item.label"
                :value="item.value"
              />
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


      classNum:[
        {
          value: '计科1班',
          label: '计科1班',
        },
        {
          value: '计科2班',
          label: '计科2班',
        },
        {
          value: '软工1班',
          label: '软工1班',
        },
        {
          value: '软工2班',
          label: '软工2班',
        },
        {
          value: 'AI1班',
          label: 'AI1班',
        },
      ],
         //input是用来接收输入的代码库地址的，可以传递给后端
        inputAddress:"https://github.com/yanyanyanyy/Job_submission_system",
        //classNumSelected是用来接收选择的班级的，可以传递给后端
        classNumSelected: "",
       }
       
     },
     
     methods:{
      alertInput: function(){
        this.inputAddress = prompt("请输入代码库地址");
      },
      //该函数为添加班级的函数，添加的班级会传到classNum中
      addClass:function(){
        this.classAdded = prompt("请输入要添加的班级名称");
        this.classNum.push({
          value: this.classAdded,
          label: this.classAdded,
        })
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