<template>
    <!--本页面为学生点击查看新发布的作业后的页面-->
    <div class="test2">
        <div id="setTopHeight"></div>
        <div class="top">
            <rel-row class="p">
                <span id="p1">请选择班级: </span>
                <!--请选择你的班级-->
                <el-select v-model="classNumSelected" class="m-2" placeholder="请选择你的的班级">
                    <el-option
                    v-for="item in classNum"
                    :label="item.label"
                    :value="item.value"
                    />
                </el-select>

                <!--此处为新加的选择按钮，在这里可以添加班级，添加的班级会传到classNum中-->
                <el-button id="bu2" type="primary" @click="addClass()">添加班级</el-button>

        
                <span id="p2"><el-text size="large" type="warning"> {{ inputAddress }}</el-text> 
                <!--点击代码库地址之后可以修改代码库-->
                <el-button id="addr" type="warning" @click="alertInput()">修改代码库地址</el-button>  </span>
       
            </rel-row>
        </div>
<br>
        <div class="studentUnsubmmitTask">
        
         <span id="p2">请查看您的作业:</span>
        
         
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
     
       <el-button type="info">返回上一页</el-button>
     </div>
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
   
   .test2{
    #setTopHeight{
        height:8px;
    }
    background-image: url('/images/svgs/login-bg.svg');
    .top{
        .p{font-size:15px; color:white;}
        #p1{margin-left:5px;}
        .m-2{margin-left:5px;}
        #bu2{margin-left:1px;}
        
        #p2{ float:right; #addr{margin-left:3px;}}
    }
    
   }
     .studentUnsubmmitTask{
        width: 100%;
        height: 100%;
        #p2{
            color:#7e9def;
            font-size:20px;
        }
       
       .el-button{
         float:right;
         float:bottom;
       }
     }
       
  
  
   </style>