<template>
    <div class="teacherCorrect">
    
        <!--本页面是教师点击批改作业按钮之后跳转到的页面-->
        <div class="top">

            <span class="top-left">
                <el-text class="mx-1" type="warning" size="large">请选择班级  </el-text>
                <el-select v-model="label" placeholder="please select your class" @change="SelectClass">
                    <el-option v-for="(course,index) in classInfo" :label="course.courseName" :value="course.id" :key="course.id" />
                </el-select>
            </span>

            <span class="top-right">
                <el-text class="mx-1" type="warning" size="large">请选择要批改哪一次作业  </el-text>
                <el-select v-model="workIndex" placeholder="please select the assignment" @change="$forceUpdate()">
                    <el-option v-for="(task,index) in taskInfo" :label="task.desc" :value="index" :key="index" />
                </el-select>
            </span>

            <!-- 点击查询之后在第一行下面应该会出现一系列数据，每一行数据包括 学号，姓名，选择某一个学号/姓名之后在右边会出现他的作业号等数据，点击某一行作业会跳转至批改界面 -->
            <span class="select"><el-button @click="select" type="primary" :icon="Search">查询</el-button></span>
            <router-link to="/TeacherRealeasePage">
                <span><el-button @click="inquery" type="success" :icon="Link" >发布作业</el-button></span>
            </router-link>
        </div>
  
        <el-container class="layout-container-demo" style="height: 575px">
            <el-main>
                <el-scrollbar>
                <!-- 把message改成messageClicked，就可以实现动态选中左侧按钮右侧出现数据了 -->
                    <el-table :data="submitInfo" @row-click="correct" :row-class-name="rowStyle">
                        <el-table-column prop="studentId" label="学号" width="150" />
                        <el-table-column prop="userName" label="姓名" width="100" />
                        <el-table-column prop="index" label="作业号" width="180" />
                        <el-table-column prop="created" label="创建时间" width="180" />
                        <el-table-column prop="updated" label="更新时间" width="180" />
                        <el-table-column prop="isCorrected" label="是否提交" width="180" />
                    </el-table>
                </el-scrollbar>
  
            </el-main>
    
          
         </el-container>
    </div>
  </template>
    
<script>
    import axios from '../../api/config'
    import { ElMessage, ElMessageBox } from 'element-plus'
    export default {
        data() {
            return {
                classInfo: null,
                taskInfo: null,
                submitInfo: null,
                now_classID: 0,
                studentId: null,
                workIndex: null,
                label: null
            }
        },
        created() {
            axios.get('api/TeacherWork/getClass?id=' + this.$cookies.get("userInfo").userId).then(
                response => {
                    this.classInfo = response.data;
                    console.log(this.classInfo);
                }
            )
            
        },
        methods: {
            SelectClass(value) {
                this.$forceUpdate();
                this.now_classID = value;
                axios.get('api/TeacherWork/getTask?id=' + value).then(
                    response => {
                        this.taskInfo = response.data;
                        console.log(this.taskInfo);
                    }
                )
                console.log(value)
            },
            
            select() {
                console.log(this.now_classID,this.workIndex);
                axios.get('api/TeacherWork/getAllSubmission?classId='+this.now_classID+'&index=' + this.workIndex).then(
                    response => {
                        this.submitInfo = response.data;
                        console.log(this.submitInfo);
                    }
                )
            },
            correct(data) {
                console.log(data)
                this.$router.push('/CorrectCodePage?classId=' + this.label + '&studentId=' + data.studentId + '&workIndex=' +(parseInt(data.index)+1))
            },
            rowStyle({row, rowIndex}){
                if(row.isCorrected){
                    return 'success_class';
                }else{
                    return 'error_class';
                }
            }

        }
    }
</script>
    
<style lang="scss" scoped>
    .teacherCorrect{
        //text-align:center;
        position:absolute;
        width: 100%;
        height: 100%;
        background-image: url('../../public/images/svgs/login-bg.svg');
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
<style>
    .error_class{
        color: red;
    }
</style>
    