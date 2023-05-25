<template>
    <!--本页面为学生点击查看新发布的作业后的页面-->
    <h1>请查看您的作业</h1>
    <div class="demo-collapse">
    <el-collapse v-model="activeNames" @change="handleChange">
      <el-collapse-item title="作业001" name="1">
        <div>
          作业要求：
        </div>
        
        <div>
          {{ assignmentNum[0].assignmentRequest }}
        </div>
      </el-collapse-item>
      <el-collapse-item title="作业002" name="2">
        <div>
          作业要求：
        </div>
        <div>
          {{ assignmentNum[1].assignmentRequest }}
        </div>
      </el-collapse-item>
      <el-collapse-item title="作业003" name="3">
        <div>
         作业要求：
        </div>
        <div>
          {{ assignmentNum[2].assignmentRequest }}
        </div>
  
      </el-collapse-item>
      <el-collapse-item title="作业004" name="4">
        <div>
          作业要求：
        </div>
        <div>
          {{ assignmentNum[3].assignmentRequest }}
        </div>
      </el-collapse-item>
    </el-collapse>
  </div>
  
  <!--返回按钮-->
    <el-button type="info">返回上一页</el-button>
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
        
      }
    }
  </script>
  
  <style scoped>
  
  </style>