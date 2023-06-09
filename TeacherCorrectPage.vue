<template>
  <div class="teacherCorrect">
  
      <!--本页面是教师点击批改作业按钮之后跳转到的页面-->
      <div class="top">
<!--
        <span class="top-left">
          <el-text class="mx-1" type="warning" size="large">请选择班级  </el-text>
              <el-select v-model="classNum" placeholder="please select your class">
                <el-option label="计科6班" value="cs-class6" />
                <el-option label="计科3班" value="cs-class3" />
              </el-select>
        </span>
-->
        <span class="top-left">
          <el-text class="mx-1" type="warning" size="large">请选择班级  </el-text>
          <el-select v-model="classNumSelected" class="m-2" placeholder="请选择你的的班级">
              <el-option
                v-for="item in classNum"
                :label="item.label"
                :value="item.value"
              />
              </el-select>
        </span>

        <span class="top-right">
          
          <el-text class="mx-1" type="warning" size="large">请选择要批改哪一次作业  </el-text>
              <el-select v-model="assignmentNum" placeholder="请选择作业号">
                <el-option label="作业1" value="Assignment 1" />
                <el-option label="作业2" value="Assignment 2" />
              </el-select>
        </span>
        
        <!-- 点击查询之后在第一行下面应该会出现一系列数据，每一行数据包括 学号，姓名，选择某一个学号/姓名之后在右边会出现他的作业号等数据，点击某一行作业会跳转至批改界面 -->
        <span class="select"><el-button @onclick="inquery" type="primary" :icon="Search" >查询</el-button></span>
        <span ><el-button @onclick="inquery" type="success" :icon="Link" >发布作业</el-button></span>
        &nbsp;
        <!--具体功能可以参照StudentUnsubmmitTaskPage里面的添加班级，但是这里没做，展示的时候-->
        <span><el-button type="primary">添加班级</el-button> </span>
      </div>
          
          
<br>
      
          <!--将原本的上下结构的界面改成左右结构-->
          <el-container class="layout-container-demo" style="height: 575px">
        <!--左侧菜单栏-->
          <el-main>
            <el-scrollbar>
              <!-- 把message改成messageClicked，就可以实现动态选中左侧按钮右侧出现数据了 -->
              <el-table :data="data">
                  <el-table-column prop="commit.student.studentId" label="学号" width="150" />
                  <el-table-column prop="commit.student.userName" label="姓名" width="100" />  
  
              </el-table>
            </el-scrollbar>

          </el-main>
  
        <el-container > 
          <!--右侧菜单栏-->
          <el-main>
            <el-scrollbar>
              <!-- 把message改成messageClicked，就可以实现动态选中左侧按钮右侧出现数据了 -->
              <el-table :data="data">
                  <el-table-column prop="commit.assignmentNum" label="作业号" width="180" />
                  <el-table-column prop="" label="提交详情" width="180" />
                  <el-table-column prop="" label="代码" width="180" />
                  <el-table-column prop="commit.created" label="创建时间" width="180" />
                  <el-table-column prop="commit.updated" label="更新时间" width="180" />
                  <el-table-column prop="commit.modified" label="是否改进" width="180" />
                  <el-table-column prop="commit.isCorrected" label="是否批改" width="180" />  
  
              </el-table>
            </el-scrollbar>
          </el-main>
        </el-container>
          </el-container>


        <!--返回按钮-->
        <el-button class="back" type="info">返回上一页</el-button>
  </div>
</template>
  
<script setup lang="ts">
  import {Search,Link } from '@element-plus/icons-vue'
  import { reactive } from 'vue'


const classNum = [{
  value:'计科1班',
  label:'计科1班',
  },
                {
  value:'计科2班',
  label:'计科2班',
  },
                {
  value:'计科3班',
  label:'计科3班',
  },
                {
  }
]
//TODO:这个变量是老师实际要查询的课程号，留出接口供数据库使用


const assignmentNum = reactive({
  value:'',
  label:'',
})
//TODO:这个变量是老师实际要查询的作业号，留出接口供数据库使用


//点击查询之后会出现查询界面
function inquery(){}

//classNumSelected是老师选择的班级，留出接口供数据库使用
const classNumSelected = ""
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
        studentId: '2021302111001',
        userName: '张三',
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
        studentId: '2021302111002',
        userName: '李四',
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
        studentId: '2021302111003',
        userName: '王五',
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
        studentId: '2021302111001',
        userName: '张三',
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
        studentId: '2021302111001',
        userName: '张三',
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
        studentId: '2021302111001',
        userName: '张三',
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
        studentId: '2021302111001',
        userName: '张三',
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
        studentId: '2021302111001',
        userName: '张三',
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
        studentId: '2021302111001',
        userName: '张三',
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
        studentId: '2021302111001',
        userName: '张三',
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
        studentId: '2021302111001',
        userName: '张三',
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
        studentId: '2021302111001',
        userName: '张三',
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
        studentId: '2021302111001',
        userName: '张三',
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
        studentId: '2021302111001',
        userName: '张三',
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
  