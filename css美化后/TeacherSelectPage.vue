<template>
  <div class="teacherSelect">
    <el-container class="layout-container-demo" style="height: 575px">
      <!--左侧菜单栏-->
      <el-aside width="200px" >
        <el-scrollbar>
          <el-menu :default-openeds="['1', '3']">
            <el-sub-menu index="1">
              <template #title>
                <el-icon><message /></el-icon>姓名/学号
              </template>
              <!--左侧栏，实现显示学号/姓名-->
              <el-menu-item-group>
                <!-- 加一个方法，点击左边出现右边，未完成 -->
                <el-menu-item  v-for="item in message" >{{item.commit.student.userName}}/{{ item.commit.student.studentId }}</el-menu-item>
              </el-menu-item-group>
              
            </el-sub-menu>
            

          </el-menu>
        </el-scrollbar>
      </el-aside>

      <el-container >
        <el-header style="text-align: right; font-size: 12px">
          <div class="toolbar">
            <el-dropdown>
              <el-icon style="margin-right: 8px; margin-top: 1px"
                ><setting
              /></el-icon>
              <template #dropdown>
                <el-dropdown-menu>
                  <el-dropdown-item>View</el-dropdown-item>
                  <el-dropdown-item>Add</el-dropdown-item>
                  <el-dropdown-item>Delete</el-dropdown-item>
                </el-dropdown-menu>
              </template>
            </el-dropdown>
            <!--这里显示点击了谁的作业-->
            <h1>张三/2021302111001</h1>
          </div>
        </el-header>

        <!--右侧数据-->
        <el-main>
          <el-scrollbar>
            <!-- 把message改成messageClicked，就可以实现动态选中左侧按钮右侧出现数据了 -->
            <el-table :data="message">
                <el-table-column prop="commit.assignmentNum" label="作业号" width="180" />
                <el-table-column prop="" label="提交详情" width="180" />
                <el-table-column prop="" label="代码" width="180" />
                <el-table-column prop="commit.created" label="创建时间" width="180" />
                <el-table-column prop="commit.updated" label="更新时间" width="180" />
                <el-table-column prop="commit.modified" label="是否改进" width="180" />
                <el-table-column prop="commit.isCorrected" label="是否批改" width="180" />  

            </el-table>
          </el-scrollbar>
          <!--点击之后返回上一页 -->
          <el-button type="info">返回上一页</el-button>
        </el-main>
      </el-container>
    </el-container>
   </div> 
  </template>
  
  <script>
    export default{
        data(){
            return{
              
                message:[
    {
      "date": {
        "year": 0,
        "month": 0,
        "day": 0,
        "dayOfWeek": 0,
        "dayOfYear": 0,
        "dayNumber": 0
      },
      "temperatureC": 0,
      "temperatureF": 0,
      "summary": "string",
  
      "commit": {
        "student": {
          "id": 0,
          "studentId": "2021302111001",
          "userName": "张三",
          "college": "计算机学院"
        },
        "assignmentNum":"assignment1",
        "index": 0,
        "created": "2023-05-23T10:41:17.111Z",
        "updated": "2023-05-23T10:41:17.111Z",
        "modified": true,
        "isCorrected": true
      }
    },{
      "date": {
        "year": 0,
        "month": 0,
        "day": 0,
        "dayOfWeek": 0,
        "dayOfYear": 0,
        "dayNumber": 0
      },
      "temperatureC": 0,
      "temperatureF": 0,
      "summary": "string",
  
      "commit": {
        "student": {
          "id": 0,
          "studentId": "2021302111002",
          "userName": "李四",
          "college": "计算机学院"
        },
        "assignmentNum":"assignment1",
        "index": 0,
        "created": "2023-05-23T10:41:17.111Z",
        "updated": "2023-05-23T10:41:17.111Z",
        "modified": true,
        "isCorrected": true
      }
    },{
      "date": {
        "year": 0,
        "month": 0,
        "day": 0,
        "dayOfWeek": 0,
        "dayOfYear": 0,
        "dayNumber": 0
      },
      "temperatureC": 0,
      "temperatureF": 0,
      "summary": "string",
  
      "commit": {
        "student": {
          "id": 0,
          "studentId": "2021302111003",
          "userName": "王五",
          "college": "计算机学院"
        },
        "assignmentNum":"assignment1",
        "index": 0,
        "created": "2023-05-23T10:41:17.111Z",
        "updated": "2023-05-23T10:41:17.111Z",
        "modified": true,
        "isCorrected": true
      }
    }
  ],

//TODO: 这里的message应该是点击左侧某个同学的学号/姓名后动态更新的
messageClicked:"",


            }
        },
        methods:{
          getValue:function(){}
            
        },
        
        //TODO: 点击学号、姓名列表中的某个项时右侧会出现提交作业的具体情况，应该是要写个函数的，目前实现是静态的
        getMessageClicked:function(){}
    }
  </script>
  
  <style lang="scss" scoped>
  .teacherSelect{
      position:absolute;
      width: 100%;
      height: 100%;
  }
  .layout-container-demo .el-header {
    position: relative;
    background-color: var(--el-color-primary-light-7);
    color: var(--el-text-color-primary);
  }
  .layout-container-demo .el-aside {
    color: var(--el-text-color-primary);
    background-color: white;
  }
  .layout-container-demo .el-menu {
    border-right: none;
  }
  .layout-container-demo .el-main {
    padding: 0;
  }
  .layout-container-demo .toolbar {
    display: inline-flex;
    align-items: center;
    justify-content: center;
    height: 100%;
    right: 20px;
  }
  </style>