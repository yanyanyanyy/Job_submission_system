<template>
  <div class="teacherCorrect">
  
      <!--本页面是教师点击批改作业按钮之后跳转到的页面-->
      <div class="top">

        <span class="top-left">
          <el-text class="mx-1" type="warning" size="large">请选择班级  </el-text>
              <el-select v-model="classNum" placeholder="please select your class">
                <el-option label="计科6班" value="cs-class6" />
                <el-option label="计科3班" value="cs-class3" />
              </el-select>
        </span>

        <span class="top-right">
          <el-text class="mx-1" type="warning" size="large">请选择要批改哪一次作业  </el-text>
              <el-select v-model="assignmentNum" placeholder="please select the assignment">
                <el-option label="作业1" value="Assignment 1" />
                <el-option label="作业2" value="Assignment 2" />
              </el-select>
        </span>

        <!-- 点击查询之后在第一行下面应该会出现一系列数据，每一行数据包括 学号，姓名，选择某一个学号/姓名之后在右边会出现他的作业号等数据，点击某一行作业会跳转至批改界面 -->
        <span class="select"><el-button @onclick="inquery" type="primary" :icon="Search" >查询</el-button></span>
      </div>
      
          <!--点击查询之后会出现一个学号、姓名列表，然后点击列表会出现提交作业的具体情况-->
          <el-table :data="data" height="200" style="width: 100%">
            <el-table-column prop="commit.student.studentId" label="学号" width="180" />
            <el-table-column prop="commit.student.userName" label="姓名" width="180" />
          </el-table>

<br>
      
          <!--点击学号、姓名列表中的某个项时会出现提交作业的具体情况--> 
          <el-table :data="data" height="250" style="width: 100%" >
              <el-table-column prop="commit.assignmentNum" label="作业号" width="180" />
              <el-table-column prop="" label="提交详情" width="180" />
              <el-table-column prop="" label="代码" width="180" />
              <el-table-column prop="commit.created" label="创建时间" width="180" />
              <el-table-column prop="commit.updated" label="更新时间" width="180" />
              <el-table-column prop="commit.modified" label="是否改进" width="180" />
              <el-table-column prop="commit.isCorrected" label="是否批改" width="180" />
          </el-table>

        <!--返回按钮-->
        <el-button class="back" type="info">返回上一页</el-button>
  </div>
</template>
  
<script setup lang="ts">
  import {Search } from '@element-plus/icons-vue'
  import { reactive } from 'vue'


const classNum = reactive({
  value:'',
  label:'',
})
//TODO:这个变量是老师实际要查询的课程号，留出接口供数据库使用


const assignmentNum = reactive({
  value:'',
  label:'',
})
//TODO:这个变量是老师实际要查询的作业号，留出接口供数据库使用


//点击查询之后会出现查询界面
function inquery(){}

const data = [
  {
    date:{
      year:0,
      month:0,
      day:0,
      dayOfWeek:0,
      dayOfYear:0,
      dayOfNumber:0,
    },
    weather:{
      temperatureC:0,
      temperatureF:0,
      summary:'string',
    },
    commit:{
      student:{
        id:0,
        studentId: '2021302111177',
        userName: '付川恒',
        college: '计算机学院',
      },
      assignmentNum:'assignment1',
      index: 0,
      created:'2023-05-23T10:41:17.111Z',
      updated:'2023-05-23T10:41:17.111Z',
      modified:true,
      isCorrected:true,
    },
  },
  {
    date:{
      year:0,
      month:0,
      day:0,
      dayOfWeek:0,
      dayOfYear:0,
      dayOfNumber:0,
    },
    weather:{
      temperatureC:0,
      temperatureF:0,
      summary:'string',
    },
    commit:{
      student:{
        id:0,
        studentId: '2021302111177',
        userName: '付川恒',
        college: '计算机学院',
      },
      assignmentNum:'assignment1',
      index: 0,
      created:'2023-05-23T10:41:17.111Z',
      updated:'2023-05-23T10:41:17.111Z',
      modified:true,
      isCorrected:true,
    },
  },
  {
    date:{
      year:0,
      month:0,
      day:0,
      dayOfWeek:0,
      dayOfYear:0,
      dayOfNumber:0,
    },
    weather:{
      temperatureC:0,
      temperatureF:0,
      summary:'string',
    },
    commit:{
      student:{
        id:0,
        studentId: '2021302111177',
        userName: '付川恒',
        college: '计算机学院',
      },
      assignmentNum:'assignment1',
      index: 0,
      created:'2023-05-23T10:41:17.111Z',
      updated:'2023-05-23T10:41:17.111Z',
      modified:true,
      isCorrected:true,
    },
  },
]
</script>
  
  <style lang="scss" scoped>
    .teacherCorrect{
        //text-align:center;
        position:absolute;
        width: 100%;
        height: 100%;
        background-image: url('/images/svgs/login-bg.svg');
        color:white;

        .top{
          margin-top: 15px;
          margin-bottom: 20px;
          .top-left{
            margin-left:15px;
            margin-right:60px;
          }
          .top-right{
            margin-right: 35px;
          }
          .select{
            float:right;
            margin-right:30px;
          }
        }
        .back{
          float:right;
        }
    }
</style>
  