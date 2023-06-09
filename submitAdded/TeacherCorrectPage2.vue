<template>
  <!--本页面是教师点击批改作业按钮之后跳转到的页面-->
    <div>
      <!--后续功能的实现-->
      <div>
      </div>  
      
      请选择班级：
      <!--适用广泛的基础单选 v-model 的值为当前被选中的 el-option 的 value 属性值-->
      <el-select v-model="classNumSelected" class="m-2" placeholder="Select">
        <el-option
          v-for="item in classNum"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        />
      </el-select>
      &nbsp;&nbsp;
        请选择要批改哪一次作业：
        
        <el-select v-model="assignmentNumSelected" class="m-2" placeholder="Select">
        <el-option
          v-for="item in assignmentNum"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        />
      </el-select>
  
      &nbsp;&nbsp;
        <!-- 点击查询之后在第一行下面应该会出现一系列数据，每一行数据包括 学号，姓名，选择某一个学号/姓名之后在右边会
          出现他的作业号等数据，点击某一行作业会跳转至批改界面 -->
        <el-button @onclick="inquery">查询</el-button>
  
      
      <!--点击查询之后会出现一个学号、姓名列表，然后点击列表会出现提交作业的具体情况-->
      <div>
  
      <br>
      <!--当 el-table 元素中注入 data 对象数组后，在 el-table-column 中用 prop 属性来对应对象中的键名即可填入数据，用 label 属性来定义表格的列名。 可以使用 width 属性来定义列宽。-->
      <el-table :data="message" border style="width: 100%">
      <el-table-column prop="commit.student.studentId" label="学号" width="180" />
      <el-table-column prop="commit.student.userName" label="姓名" width="180" />
      </el-table>
      </div>  
      
      <br>
      <!--点击学号、姓名列表中的某个项时会出现提交作业的具体情况--> 
      <div>
      <el-table :data="message" border style="width: 100%" >
      <el-table-column prop="commit.assignmentNum" label="作业号" width="180" />
      <el-table-column prop="" label="提交详情" width="180" />
      <el-table-column prop="" label="代码" width="180" />
      <el-table-column prop="commit.created" label="创建时间" width="180" />
      <el-table-column prop="commit.updated" label="更新时间" width="180" />
      <el-table-column prop="commit.modified" label="是否改进" width="180" />
      <el-table-column prop="commit.isCorrected" label="是否批改" width="180" />
      </el-table>
      </div>
  
    </div>
  <!--返回按钮-->
<el-button type="info">返回上一页</el-button>
  </template>
  
  <script >
  
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
          "studentId": "2021302111177",
          "userName": "付川恒",
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
          "studentId": "2021302111177",
          "userName": "付川恒",
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
          "studentId": "2021302111177",
          "userName": "付川恒",
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
                    //TODO:后端传进来好几个课程号，现在假设是class1，class2，class3,具体是什么要取决于后端传过来的数值
  
  classNum:[
      {
        value: 'class1',
        label: 'class1',
      },
      {
        value: 'class2',
        label: 'class2',
      },
      {
        value: 'class3',
        label: 'class3',
      },
      {
        value: 'class4',
        label: 'class4',
      },
      {
        value: 'class5',
        label: 'class5',
      },
    ],
  
                //TODO:这个变量是老师实际要查询的课程号，留出接口供数据库使用
                classNumSelected:"",
  
                //TODO:后端传进来好几个作业号，现在假设是assignment1，assignment2，assignment3,具体是什么要取决于后端传过来的数值
                assignmentNum:[
      {
        value: 'assignment1',
        label: 'assignment1',
      },
      {
        value: 'assignment',
        label: 'assignment',
      },
      {
        value: 'assignment',
        label: 'assignment',
      },
      {
        value: 'assignment',
        label: 'assignment',
      },
      {
        value: 'assignment',
        label: 'assignment',
      },
    ],
                //TODO:这个变量是老师实际要查询的作业号，留出接口供数据库使用
                assignmentNumSelected:"",
  
  
                
              }
              
          },
          methods:{
            //点击查询之后会出现查询界面
            inquery:function(){
              
            },
            //获取下拉框选中的值并赋值给assignmentNumSelected
            getvaluemethod2:function(event){
                _this.assignmentNumSelected = event.target.value;
            },
            //获取下拉框选中的值并赋值给studentSelected
            getvaluemethod3:function(event){
                _this.studentSelected = event.target.value;
            }
          }
      } 
  
  </script>
  
  <style scoped>
  /*这里是想将*/
  
  </style>
  